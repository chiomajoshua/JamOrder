using JamOrder.Core.Helpers;
using JamOrder.Core.Services.DataRepository.Interface;
using JamOrder.Core.Services.Token.Config;
using JamOrder.Core.Services.Token.Interface;
using JamOrder.Data.Models;
using Microsoft.Extensions.Logging;

namespace JamOrder.Core.Services.Token.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository, ILogger<TokenService> logger)
        {
            _tokenRepository = tokenRepository;
            _logger = logger;            
        }

        public async Task<string> CreateToken(string customerId)
        {
            try
            {
                var token = Extensions.Encrypt($"{customerId}{Guid.NewGuid().ToString().Replace("-", "")}+{DateTime.Now.Ticks}");
                var result = await SaveToken(new CreateTokenRequest { CustomerId = customerId, Token = token });
                return result ? token : "----";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CreateToken Error ----> Token Creation Failed for user {customerId}. {ex.Message}");
                return "----";
            }
        }

        public async Task<bool> ValidateToken(ValidateTokenRequest validateTokenRequest)
        {
            try
            {
                return await _tokenRepository.AnyAsync(x => x.CustomerId == validateTokenRequest.CustomerId && 
                                                                        x.Token == validateTokenRequest.Token &&
                                                                        DateTime.Now <= x.ExpiresAt &&
                                                                        x.IsActive == true);               
            }
            catch (Exception ex)
            {
                _logger.LogError($"ValidateToken Error ----> Token Validation Failed for user {validateTokenRequest.CustomerId}. {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DestroyToken(string customerId)
        {
            return await _tokenRepository.UpdateAsync(new Data.Entities.TokenLog { IsActive = false }, x => x.CustomerId == customerId);
        }

        private async Task<bool> SaveToken(CreateTokenRequest tokenRequest)
        {
            try
            {
                return await _tokenRepository.InsertAsync(tokenRequest.ToDbToken());
            }
            catch (Exception ex)
            {
                _logger.LogError($"SaveToken Error ----> Failed to save Token {ex.Message}");
                return false;
            }
        }
    }
}
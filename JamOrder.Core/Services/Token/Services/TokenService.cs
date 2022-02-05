using JamOrder.Core.Helpers;
using JamOrder.Core.Services.Customer.Interface;
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
        private readonly ICustomerService _customerService;
        public TokenService(ITokenRepository tokenRepository, ILogger<TokenService> logger, ICustomerService customerService)
        {
            _tokenRepository = tokenRepository;
            _logger = logger;
            _customerService = customerService;
        }

        public async Task<string> CreateToken(string customerId)
        {
            try
            {
                var token = Extensions.Encrypt($"{customerId}-{Guid.NewGuid().ToString().Replace("-", "")}-{DateTime.Now.Ticks}");
                var result = await SaveToken(new CreateTokenRequest { CustomerId = customerId, Token = token });
                return result ? token : "----";
            }
            catch (Exception ex)
            {
                _logger.LogError($"CreateToken Error ----> Token Creation Failed for user {customerId}. {ex.Message}");
                return "----";
            }
        }

        public async Task<bool> ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token)) return false;
            var request = Extensions.Decrypt(token).Split('-');
            try
            {
                var customerRecords = await _customerService.GetCustomerByIdAsync(request.FirstOrDefault());
                if (customerRecords is null) return false;

                return await _tokenRepository.AnyAsync(x => x.CustomerId == request.FirstOrDefault() && 
                                                                        x.Token == token &&
                                                                        DateTime.Now <= x.ExpiresAt &&
                                                                        x.IsActive == true);               
            }
            catch (Exception ex)
            {
                _logger.LogError($"ValidateToken Error ----> Token Validation Failed for user {request.FirstOrDefault()}. {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DestroyToken(string customerId)
        {
            try
            {
                var tokenLog = await _tokenRepository.FindAllAsync(x => x.CustomerId == customerId && x.IsActive);
                if(tokenLog?.Any() == false) return true;
                tokenLog.ToList().ForEach(async x => await _tokenRepository.UpdateAsync(x, x => x.IsActive == false));

                var activeToken = await _tokenRepository.AnyAsync(x => x.CustomerId == customerId && x.IsActive);
                if (activeToken) return false;
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"DestroyToken Error ----> Failed to destroy Token {ex.Message}");
                return false;
            }
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
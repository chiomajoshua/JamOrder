using JamOrder.Core.Helpers;
using JamOrder.Core.Services.Authentication.Interface;
using JamOrder.Core.Services.DataRepository.Interface;
using JamOrder.Data.Models;
using Microsoft.Extensions.Logging;

namespace JamOrder.Core.Services.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ILogger<AuthenticationService> _logger;
        public AuthenticationService(IAuthenticationRepository authenticationRepository, ILogger<AuthenticationService> logger)
        {
            _authenticationRepository = authenticationRepository;
            _logger = logger;
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            try
            {
                _logger.LogInformation($"Login -----> {loginRequest.Email} tried to logon at {DateTime.Now}");
                var isAccountExists = await _authenticationRepository.FirstOrDefaultAsync(x => x.EmailAddress == loginRequest.Email);
                if (isAccountExists is null) return false;

                if (isAccountExists.EmailAddress == loginRequest.Email && Extensions.Decrypt(isAccountExists.Password).Equals(loginRequest.Password))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login Error ----> Login Failed for user {loginRequest.Email}. {ex.Message}");
                return false;
            }
        }
    }
}
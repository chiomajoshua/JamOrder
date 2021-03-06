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
                _logger.LogInformation(message: $"Login -----> {loginRequest.EmailAddress} tried to logon at {DateTime.Now}");
                var userAccount = await _authenticationRepository.FirstOrDefaultAsync(x => x.EmailAddress == loginRequest.EmailAddress);

                if (userAccount is null) return false;

                return userAccount.EmailAddress == loginRequest.EmailAddress && Extensions.Decrypt(userAccount.Password).Equals(loginRequest.Password, StringComparison.Ordinal);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login Error ----> Login Failed for user {loginRequest.EmailAddress}. {ex.Message}");
                return false;
            }
        }
    }
}
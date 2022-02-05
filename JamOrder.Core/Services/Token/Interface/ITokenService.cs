using JamOrder.Core.Helpers.Autofac;
using JamOrder.Data.Models;

namespace JamOrder.Core.Services.Token.Interface
{
    public interface ITokenService : IAutoDependencyCore
    {
        /// <summary>
        /// Create Token
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<string> CreateToken(string email);

        /// <summary>
        /// Validate Token
        /// </summary>
        /// <param name="validateTokenRequest"></param>
        /// <returns></returns>
        Task<bool> ValidateToken(ValidateTokenRequest validateTokenRequest);

        /// <summary>
        /// Kills Token During Logout
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> DestroyToken(string customerId);
    }
}
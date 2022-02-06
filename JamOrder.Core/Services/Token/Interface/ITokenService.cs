using JamOrder.Core.Helpers.Autofac;

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
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> ValidateToken(string token);

        /// <summary>
        /// Kills Token During Logout
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> DestroyToken(string customerId);
    }
}
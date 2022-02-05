using JamOrder.Core.Helpers.Autofac;
using JamOrder.Data.Models;

namespace JamOrder.Core.Services.Authentication.Interface
{
    public interface IAuthenticationService : IAutoDependencyCore
    {
        /// <summary>
        /// Gain Entry to Site
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<bool> Login(LoginRequest loginRequest);
    }
}
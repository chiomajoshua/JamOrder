using JamOrder.Data.Models;

namespace JamOrder.Core.Services.Token.Config
{
    public static class TokenExtensions
    {
        public static Data.Entities.TokenLog ToDbToken(this CreateTokenRequest createTokenRequest)
        {
            return new Data.Entities.TokenLog
            {
                CustomerId = createTokenRequest.CustomerId,
                Token = createTokenRequest.Token
            };
        }
    }
}
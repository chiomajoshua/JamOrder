using JamOrder.Data.Entities;

namespace JamOrder.Data.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
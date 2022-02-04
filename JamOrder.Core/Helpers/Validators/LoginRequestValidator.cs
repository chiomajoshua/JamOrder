using FluentValidation;
using JamOrder.Data.Models;

namespace JamOrder.Core.Helpers.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull().NotEqual("string");
        }
    }
}
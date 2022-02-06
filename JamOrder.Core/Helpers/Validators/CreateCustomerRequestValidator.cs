using FluentValidation;
using JamOrder.Data.Models;

namespace JamOrder.Core.Helpers.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.LastName).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.EmailAddress).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.HouseNumber).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.StreetName).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.City).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.State).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.Country).NotEmpty().NotNull().NotEqual("string");
            RuleFor(x => x.Password).NotEmpty().NotNull().NotEqual("string");
        }
    }
}
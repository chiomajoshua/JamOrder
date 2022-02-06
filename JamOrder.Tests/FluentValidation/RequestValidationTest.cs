using JamOrder.Core.Helpers.Validators;
using JamOrder.Data.Models;
using Xunit;

namespace JamOrder.Tests.FluentValidation
{
    public class RequestValidationTest
    {
        [Fact]
        public void Test_CreateCustomerRequestValidator_Success()
        {
            var customerValidator = new CreateCustomerRequestValidator();
            var createCustomerRequest = new CreateCustomerRequest()
            {
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "testaccount@gmail.com",
                PhoneNumber = "+905338930234",
                FirstName = "Ahmet",
                HouseNumber = "4b",
                LastName = "Mehmet",
                Password = "Te$t12345",
                State = "Istanbul",
                StreetName = "Mersin 10"
            };

            var result = customerValidator.Validate(createCustomerRequest);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Test_CreateCustomerRequestValidator_Failure()
        {
            var customerValidator = new CreateCustomerRequestValidator();
            var createCustomerRequest = new CreateCustomerRequest()
            {
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "testaccount@gmail.com",
                FirstName = "Ahmet",
                HouseNumber = "4b",
                LastName = "Mehmet",
                Password = "Te$t12345",
                State = "Istanbul",
                StreetName = "Mersin 10"
            };

            var result = customerValidator.Validate(createCustomerRequest);
            Assert.Equal(2, result.Errors.Count);
        }

        [Fact]
        public void Test_LoginRequestValidator_Success()
        {
            var loginValidator = new LoginRequestValidator();
            var loginRequest = new LoginRequest()
            {
                EmailAddress = "chiomajoshua@gmail.com",
                Password = "Te$t12345"
            };

            var result = loginValidator.Validate(loginRequest);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Test_LoginRequestValidator_Failure()
        {
            var loginValidator = new LoginRequestValidator();
            var loginRequest = new LoginRequest()
            {
                EmailAddress = "chiomajoshua",
                Password = "Te$t12345"
            };

            var result = loginValidator.Validate(loginRequest);
            Assert.Single(result.Errors);
        }
    }
}
using JamOrder.Core.Services.Customer.Interface;
using JamOrder.Data.Models;
using JamOrder.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace JamOrder.Tests.APITests
{
    public class OnboardingControllerTest
    {
        readonly Mock<ICustomerService> _mockRepo = new();
        
        [Fact]
        public async Task Test_POST_CreateCustomerAsync()
        {
            var createCustomerRequest = new CreateCustomerRequest()
            {
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "testaccount@gmail.com",
                FirstName = "Ahmet",
                HouseNumber = "4b",
                LastName = "Mehmet",
                MiddleName = "Aksam",
                Password = "Te$t12345",
                PhoneNumber = "+905338930234",
                State = "Istanbul",
                StreetName = "Mersin 10"
            };

            _mockRepo.Setup(setup => setup.CreateCustomerAsync(It.IsAny<CreateCustomerRequest>())).ReturnsAsync(true);
            var onboardingContoller = new OnboardingController(_mockRepo.Object);

            var result = await onboardingContoller.Post(createCustomerRequest);

            var customerResult = result as NoContentResult;
            Assert.Equal(204, customerResult.StatusCode);
        }        
    }
}
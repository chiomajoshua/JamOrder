using JamOrder.Core.Services.Authentication.Interface;
using JamOrder.Core.Services.Customer.Interface;
using JamOrder.Core.Services.Token.Interface;
using JamOrder.Data.Models;
using JamOrder.Web.Controllers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace JamOrder.Tests.APITests
{
    public class AuthenticationControllerTest
    {
        readonly Mock<ICustomerService> _mockCustomerService = new();
        readonly Mock<IAuthenticationService> _mockAuthenticationService = new();
        readonly Mock<ITokenService> _mockTokenService = new();

        [Fact]
        public async Task Test_POST_LoginAsync()
        {
            var loginRequest = new LoginRequest()
            {
                EmailAddress = "testaccount@gmail.com",
                Password = "Te$t12345",
            };

            _mockAuthenticationService.Setup(setup => setup.Login(It.IsAny<LoginRequest>())).ReturnsAsync(true);
            var authenticationController = new AuthenticationController(_mockCustomerService.Object, _mockTokenService.Object, _mockAuthenticationService.Object);

            var result = await authenticationController.Post(loginRequest);

            var authenticationResult = result as LoginResponse;
            Assert.Same(new LoginResponse(), authenticationResult);
        }
    }
}
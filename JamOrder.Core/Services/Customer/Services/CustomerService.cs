using JamOrder.Core.Services.Customer.Config;
using JamOrder.Core.Services.Customer.Interface;
using JamOrder.Core.Services.DataRepository.Interface;
using JamOrder.Data.Models;
using Microsoft.Extensions.Logging;

namespace JamOrder.Core.Services.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<bool> CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            try
            {
                _logger.LogInformation($"CreateCustomer -----> {createCustomerRequest.EmailAddress} tried to create an account at {DateTime.Now}");              
                return await _customerRepository.InsertAsync(createCustomerRequest.ToDbCustomer());
            }
            catch (Exception ex)
            {
                _logger.LogError($"IsCustomerExists Error -----> Account Creation Failed for {createCustomerRequest}. {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IsCustomerExists(string email)
        {
            try
            {
                _logger.LogInformation($"IsCustomerExists -----> Account Exist Check for {email} at {DateTime.Now}");
                return await _customerRepository.AnyAsync(x => x.EmailAddress == email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IsCustomerExists Error -----> Account Exist Check Failed for {email}. {ex.Message}");
                return false;
            }
        }
    }
}
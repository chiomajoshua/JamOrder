using JamOrder.Data.Models;

namespace JamOrder.Core.Services.Customer.Interface
{
    public interface ICustomerService
    {
        /// <summary>
        /// Create Customer Account
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> CreateCustomer(CreateCustomerRequest createCustomerRequest);

        /// <summary>
        /// Checks if Customer Exists
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsCustomerExists(string email);

        /// <summary>
        /// Get Customer By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<CustomerResponse> GetCustomer(string email);
    }
}
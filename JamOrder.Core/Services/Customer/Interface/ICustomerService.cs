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
        Task<bool> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest);

        /// <summary>
        /// Checks if Customer Exists
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsCustomerExistsAsync(string email);

        /// <summary>
        /// Get Customer By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<CustomerResponse> GetCustomerByEmailAsync(string email);

        /// <summary>
        /// Get Customer By Customer Id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<CustomerResponse> GetCustomerByIdAsync(string id);
    }
}
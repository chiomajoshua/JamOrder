using JamOrder.Core.Helpers;
using JamOrder.Data.Models;

namespace JamOrder.Core.Services.Customer.Config
{
    public static class CustomerExtensions
    {
        public static Data.Entities.Customer ToDbCustomer(this CreateCustomerRequest createCustomerRequest)
        {
            return new Data.Entities.Customer
            {
                AccountStatus = true,
                City = createCustomerRequest.City,
                Country = createCustomerRequest.Country,
                EmailAddress = createCustomerRequest.EmailAddress,
                FirstName = createCustomerRequest.FirstName,
                LastName = createCustomerRequest.LastName,
                HouseNumber = createCustomerRequest.HouseNumber,
                MiddleName = createCustomerRequest.MiddleName,
                PhoneNumber = createCustomerRequest.PhoneNumber,
                State = createCustomerRequest.State,
                StreetName = createCustomerRequest.StreetName,
                Password = Extensions.Encrypt(createCustomerRequest.Password)
            };
        }

        public static CustomerResponse ToCustomer(this Data.Entities.Customer customer)
        {
            return new CustomerResponse
            {                
                EmailAddress = customer.EmailAddress,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MiddleName = customer.MiddleName,
                PhoneNumber = customer.PhoneNumber,
                CustomerId = customer.Id.ToString()
            };
        }
    }
}
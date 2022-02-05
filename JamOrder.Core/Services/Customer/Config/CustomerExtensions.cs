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
    }
}
using JamOrder.Core.DataRepository.Service;
using JamOrder.Core.Services.DataRepository.Interface;
using MicroOrm.Dapper.Repositories;

namespace JamOrder.Core.Services.DataRepository.Service
{
    public class CustomerRepository : GenericRepository<Data.Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(DapperRepository<Data.Entities.Customer> dapperRepository) : base(dapperRepository) { }
    }
}
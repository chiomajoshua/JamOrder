using JamOrder.Core.DataRepository.Service;
using JamOrder.Core.Services.DataRepository.Interface;
using MicroOrm.Dapper.Repositories;

namespace JamOrder.Core.Services.DataRepository.Service
{
    public class AuthenticationRepository : GenericRepository<Data.Entities.Customer>, IAuthenticationRepository
    {
        public AuthenticationRepository(DapperRepository<Data.Entities.Customer> dapperRepository) : base(dapperRepository) { }
    }
}
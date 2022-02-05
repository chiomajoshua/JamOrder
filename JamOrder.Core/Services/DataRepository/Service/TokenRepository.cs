using JamOrder.Core.DataRepository.Service;
using JamOrder.Core.Services.DataRepository.Interface;
using MicroOrm.Dapper.Repositories;

namespace JamOrder.Core.Services.DataRepository.Service
{
    public class TokenRepository : GenericRepository<Data.Entities.TokenLog>, ITokenRepository
    {
        public TokenRepository(DapperRepository<Data.Entities.TokenLog> dapperRepository) : base(dapperRepository) { }
    }
}
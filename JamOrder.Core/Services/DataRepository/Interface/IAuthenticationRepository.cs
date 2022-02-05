using JamOrder.Core.DataRepository.Interface;
using JamOrder.Core.Helpers.Autofac;

namespace JamOrder.Core.Services.DataRepository.Interface
{
    public interface IAuthenticationRepository : IGenericRepository<Data.Entities.Customer>, IAutoDependencyCore { }
}
using JamOrder.Core.DataRepository.Interface;
using JamOrder.Core.Helpers.Autofac;

namespace JamOrder.Core.Services.DataRepository.Interface
{
    public interface ICustomerRepository : IGenericRepository<Data.Entities.Customer>, IAutoDependencyCore { }
}
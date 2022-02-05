using JamOrder.Core.Helpers.Autofac;
using System.Linq.Expressions;

namespace JamOrder.Core.DataRepository.Interface
{
    public interface IGenericRepository<T> : IAutoDependencyCore
    {
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity, params Expression<Func<T, object>>[] includes);
    }
}
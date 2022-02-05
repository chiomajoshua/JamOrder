using JamOrder.Core.DataRepository.Interface;
using MicroOrm.Dapper.Repositories;
using System.Linq.Expressions;

namespace JamOrder.Core.DataRepository.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DapperRepository<T> _dapperRepository;
        public GenericRepository(DapperRepository<T> dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public virtual Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _dapperRepository.FindAsync(predicate);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dapperRepository.FindAllAsync(predicate);
            return result.FirstOrDefault();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dapperRepository.FindAsync(predicate);
            if (result is null) return false;
            return true;
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            return await _dapperRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity, params Expression<Func<T, object>>[] includes)
        {
            return await _dapperRepository.UpdateAsync(entity, includes);
        }
    }
}
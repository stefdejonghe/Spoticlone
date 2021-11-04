using Pri.Spoticlone.Core.Entities.Base;
using Pri.Spoticlone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : EntityBase
    {
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id, string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

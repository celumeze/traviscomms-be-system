using Microsoft.EntityFrameworkCore;
using Org.IdentityServer.Data;
using Org.IdentityServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Org.IdentityServer.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly TravisCommsIdentityDbContext _travisCommsIdDbContext;

        public GenericRepository(TravisCommsIdentityDbContext travisCommsIdDbContext)
        {
            _travisCommsIdDbContext = travisCommsIdDbContext;
        }

        public virtual T Add(T entity)
        {
            _travisCommsIdDbContext.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await _travisCommsIdDbContext.Set<T>().ToListAsync();
        }

        public virtual T Delete(T entity)
        {
            _travisCommsIdDbContext.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async virtual Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _travisCommsIdDbContext.Set<T>()
                   .AsQueryable()
                   .Where(predicate)
                   .ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _travisCommsIdDbContext.FindAsync<T>(id);
        }        

        public virtual async Task SaveChangesAsync()
        {
            await _travisCommsIdDbContext.SaveChangesAsync();
        }

        public virtual T Update(T entity)
        {
            _travisCommsIdDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _travisCommsIdDbContext.Set<T>()
                   .AsQueryable()
                   .Where(predicate)
                   .FirstOrDefaultAsync<T>();
        }
    }
}

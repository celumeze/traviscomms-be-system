using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Data.Repository.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly TravisCommsSqlDbContext _travisCommsSqlDbContext;

        public GenericRepository(TravisCommsSqlDbContext travisCommsSqlDbContext)
        {
            _travisCommsSqlDbContext = travisCommsSqlDbContext;
        }

        public virtual T Add(T entity)
        {
            _travisCommsSqlDbContext.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await _travisCommsSqlDbContext.Set<T>().ToListAsync();
        }

        public virtual T Delete(T entity)
        {
            _travisCommsSqlDbContext.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async virtual Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _travisCommsSqlDbContext.Set<T>()
                   .AsQueryable()
                   .Where(predicate)
                   .ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _travisCommsSqlDbContext.FindAsync<T>(id);
        }        

        public virtual async Task SaveChangesAsync()
        {
            await _travisCommsSqlDbContext.SaveChangesAsync();
        }

        public virtual T Update(T entity)
        {
            _travisCommsSqlDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _travisCommsSqlDbContext.Set<T>()
                   .AsQueryable()
                   .Where(predicate)
                   .FirstOrDefaultAsync<T>();
        }
    }
}

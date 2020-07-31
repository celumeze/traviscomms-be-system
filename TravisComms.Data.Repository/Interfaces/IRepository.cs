using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> AllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}

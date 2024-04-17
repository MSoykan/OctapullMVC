using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract {
    public interface IRepository<T> {
        Task<List<T>> ListAsync();

        Task AddAsync(T p);

        Task<T> GetAsync (Expression<Func<T, bool>> filter);

        Task DeleteAsync(T p);

        Task UpdateAsync(T p);

        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter);
    }
}

using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Repository
{
    public interface IEntityRepository<T>
        where T: EntityBase
    {
        Task Create(IEnumerable<T> items);
        Task Create(T items);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> filter);
        Task<T> Read(Guid id);
        Task<(bool, T)> Update(T item);
        Task<(bool, T)> Update(T item, Expression<Func<T, bool>> filter);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteBulk(Expression<Func<T, bool>> filter);
    }
}

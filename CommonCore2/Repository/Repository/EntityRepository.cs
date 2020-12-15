using CommonCore.Interfaces.Repository;
using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore2.Repository.Repository
{
    public class EntityRepository<T> : IEntityRepository<T>
        where T : EntityBase
    {
        private readonly ICrudRepository<T> _repository;

        public EntityRepository(
            ICrudRepository<T> repository
            )
        {
            _repository = repository;
        }

        public async Task Create(IEnumerable<T> items)
            => await _repository.Create(items);

        public async Task Create(T items)
        => await _repository.Create(items);

        public async Task<bool> DeleteBulk(Expression<Func<T, bool>> filter)
            => await _repository.Delete(filter);

        public async Task<bool> Delete(Guid id)
            => await _repository.Delete(x => x.ID == id);

        public async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> filter)
            => await _repository.Read(filter);

        public async Task<T> Read(Guid id)
        {
            var list = await _repository.Read(x => x.ID == id);
            return list.FirstOrDefault();
        }

        public async Task<(bool, T)> Update(T item, Expression<Func<T, bool>> filter)
            => await _repository.Update(item, filter);

        public async Task<(bool, T)> Update(T item)
            => await _repository.Update(item, x => x.ID == item.ID);
    }
}

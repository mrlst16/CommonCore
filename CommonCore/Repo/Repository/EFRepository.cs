using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCore.Repo.Repository
{
    class EFRepository<T> : IRepository<T, EFRepository<T>>
    {
        private object context;

        public EFRepository(object context)
        {
            this.context = context;
        }

        public EFRepository<T> Add(T item, bool save)
        {
            throw new NotImplementedException();
        }

        public EFRepository<T> Add(T item, IComparer<T> comparer, bool save)
        {
            throw new NotImplementedException();
        }

        public EFRepository<T> AddRange(IEnumerable<T> range, bool save)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQuery()
        {
            throw new NotImplementedException();
        }

        public EFRepository<T> Remove(T item, bool save)
        {
            throw new NotImplementedException();
        }

        public EFRepository<T> RemoveRange(IEnumerable<T> range, bool save)
        {
            throw new NotImplementedException();
        }

        public EFRepository<T> Save()
        {
            throw new NotImplementedException();
        }
    }
}

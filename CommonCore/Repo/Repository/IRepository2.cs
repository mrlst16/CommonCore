using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCore.Repo.Repository
{
    public interface IRepository2<T, TRepo>
        where TRepo : IRepository2<T, TRepo>
    {
        TRepo Add(T item, bool save);
        TRepo Add(T item, IComparer<T> comparer, bool save);
        TRepo Remove(T item, bool save);
        TRepo AddRange(IEnumerable<T> range, bool save);
        TRepo RemoveRange(IEnumerable<T> range, bool save);
        IQueryable<T> GetQuery();
        TRepo Save();
    }
}

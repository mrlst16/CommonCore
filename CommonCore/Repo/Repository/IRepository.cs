using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Repo.Repository
{
    public interface IRepo { }

    public interface IRepository<T, TRepo> : IRepo
        where TRepo: IRepository<T, TRepo>
        where T: class
    {
        TRepo Add(T item, bool save);
        TRepo Add(T item, IComparer<T> comparer, bool save);
        TRepo Remove(T item, bool save);
        TRepo AddRange(IEnumerable<T> range, bool save);
        TRepo RemoveRange(IEnumerable<T> range, bool save);
        TRepo RemoveRange(Func<T, bool> wherePredicate, bool save = false);
        DbSet<T> Set();
        IQueryable<T> GetQuery();
        TRepo Save();
        IRepository<G, GRepo> Spawn<G, GRepo>()
            where G : class
            where GRepo : IRepository<G, GRepo>;
    }
}

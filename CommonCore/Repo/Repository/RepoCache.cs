using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Extensions;
using CommonCore.Repo.Entities;
using CommonCore.Repo.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace CommonCore.Repo.Repository
{
    internal class ContextBag
    {
        internal Type Type;
        internal IEnumerable<string> EntityNames;
        internal Dictionary<string, IRepoAdapter> RepoAdapters = new Dictionary<string, IRepoAdapter>();
    }

    public static class RepoCache
    {
        private static List<ContextBag> _contextBags = new List<ContextBag>();
        private static List<ContextBag> ContextBags
        {
            get
            {
                var lockObject = new object();
                lock (lockObject)
                {
                    return _contextBags;
                }
            }
        }

        public static void Initialize(params Type[] contextTypes)
        {
            foreach (var contextType in contextTypes)
            {
                try
                {
                    ContextBag bag = new ContextBag()
                    {
                        EntityNames = GetEntityNames((DbContext)Activator.CreateInstance(contextType)),
                        Type = contextType
                    };
                    ContextBags.Add(bag);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static DbContext GetContext(Type type)
        {
            var lockObject = new object();
            var bag = ContextBags.FirstOrDefault(x => x.Type == type);
            lock (lockObject)
            {
                return (DbContext)Activator.CreateInstance(type);
            }
        }

        public static IQueryable<T> GetQuery<T>()
            where T : class, IEntity
        {
            return Get<T>().GetQuery();
        }

        public static Repository<T> Get<T>()
            where T : class, IEntity
        {
            try
            {
                var key = typeof(T).FullName;
                var contextBag = ContextBags.FirstOrDefault(x => x.EntityNames.Contains(key));

                if (contextBag == null)
                    throw new Exception($"Type {key} could not be found in any of the cached contexts");

                return new Repository<T>((DbContext)Activator.CreateInstance(contextBag.Type));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Repository<T> Create<T, TContext>()
            where T : class, IEntity
            where TContext : DbContext, new()
        {
            return new Repository<T>(new TContext());
        }

        private static IEnumerable<string> GetEntityNames(DbContext dbContext)
        {
            return dbContext.Model.GetEntityTypes().Select(x => x.Name);
        }

        public static List<ReturnT> RunSproc<ReturnT>(RunSprocRequest request
            )
        where ReturnT : class
        {
            string command = $"exec {request.SprocName} {request.Parameters.ToSqlParamsString()}";

            return GetContext(request.ContextType).Query<ReturnT>().FromSql(new RawSqlString(command)).ToList();
        }

    }
}
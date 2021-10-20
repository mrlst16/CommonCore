using CommonCore.Repo.Entities;
using System;

namespace CommonCore.Repo
{
    public static class RepoExtensions
    {
        public static T EnsureID<T>(this T obj)
            where T : IEntity
        {
            if (obj.ID == Guid.Empty)
                obj.ID = Guid.NewGuid();
            return obj;
        }
    }
}

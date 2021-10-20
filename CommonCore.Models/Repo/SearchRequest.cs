using System;
using System.Linq.Expressions;

namespace CommonCore.Models.Repo
{
    public class SearchRequest<T>
    {
        public int? Limit { get; set; }
        public int? Skip { get; set; }
        public Expression<Func<T, bool>> Filter { get; set; }
    }
}

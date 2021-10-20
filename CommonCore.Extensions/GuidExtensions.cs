using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonCore.Extensions
{
    public static class GuidExtensions
    {
        public static string Merge(this Guid one, Guid two)
            => new List<Guid>() { one, two }
                .OrderBy(x => x.GetHashCode())
                .Select(y => y.ToString().ToLowerInvariant())
                .Aggregate((a, b) => $"{a.ToLowerInvariant()}_{b.ToLowerInvariant()}");
    }
}

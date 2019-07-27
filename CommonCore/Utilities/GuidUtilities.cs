using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCore.Utilities
{
    public static class GuidUtilities
    {
        public static string Merge(Guid one, Guid two)
        {
            return new List<Guid>() { one, two }
                .OrderBy(x => x.GetHashCode())
                .Select(y => y.ToString().ToLowerInvariant())
                .Aggregate((a, b) => $"{a.ToLowerInvariant()}_{b.ToLowerInvariant()}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonCore.Extensions
{
    public static class LinqExtensions
    {

        public static bool None<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }

        public static bool None<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return list == null || !list.Any(predicate);
        }

        public static IDictionary<K, V> AddRange<K, V>(this IDictionary<K, V> one, IDictionary<K, V> two)
        {
            foreach (var kvp in two)
            {
                if (one.ContainsKey(kvp.Key))
                    one[kvp.Key] = two[kvp.Key];
                else
                    one.Add(kvp.Key, kvp.Value);
            }
            return one;
        }

        public static bool Contains<T>(this IEnumerable<T> one, T value, Func<T, bool> expression)
            => one.Any(expression);

        public static IEnumerable<T> RangeBetween<T>(this IEnumerable<T> list, int start, int end)
            => list.Skip(start).Take(list.Count() - end);

        public static IEnumerable<T> RangeBetweenInclusive<T>(this IEnumerable<T> list, int start, int end)
        {
            var take = end - start + 1;
            var result = list.Skip(start).Take(take);
            return result;
        }

        public static IEnumerable<T> Distinct<T, T2>(this IEnumerable<T> list, Func<T, T2> predicate)
            => list.GroupBy(predicate)
                .Select(x => x.FirstOrDefault());

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
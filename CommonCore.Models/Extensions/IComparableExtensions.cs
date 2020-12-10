using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Models.Extensions
{
    public static class IComparableExtensions
    {

        public static bool IsLessThan<T>(this T compareThis, T comparedTo)
            where T : IComparable<T>
        {
            return compareThis.CompareTo(comparedTo) < 0;
        }

        public static bool IsLessThanOrEqualTo<T>(this T compareThis, T comparedTo)
            where T : IComparable<T>
        {
            var result = compareThis.CompareTo(comparedTo);
            return result <= 0;
        }

        public static bool IsGreaterThan<T>(this T compareThis, T comparedTo)
            where T : IComparable<T>
        {
            var result = compareThis.CompareTo(comparedTo);
            return result > 0;
        }

        public static bool IsGreaterThanOrEqualTo<T>(this T compareThis, T comparedTo)
            where T : IComparable<T>
        {
            var result = compareThis.CompareTo(comparedTo);
            return result >= 0;
        }

        public static bool IsEqualTo<T>(this T compareThis, T comparedTo)
            where T : IComparable<T>
        {
            var result = compareThis.CompareTo(comparedTo);
            return result == 0;
        }

        public static bool IsNotEqualTo<T>(this T compareThis, T comparedTo)
            where T : IComparable<T>
        {
            var result = compareThis.CompareTo(comparedTo);
            return result != 0;
        }

        public static bool IsLessThan<T>(this IComparable<T> compareThis, T comparedTo)
        {
            return compareThis.CompareTo(comparedTo) < 0;
        }

        public static bool IsLessThanOrEqualTo<T>(this IComparable<T> compareThis, T comparedTo)
        {
            var result = compareThis.CompareTo(comparedTo);
            return result <= 0;
        }

        public static bool IsGreaterThan<T>(this IComparable<T> compareThis, T comparedTo)
        {
            var result = compareThis.CompareTo(comparedTo);
            return result > 0;
        }

        public static bool IsGreaterThanOrEqualTo<T>(this IComparable<T> compareThis, T comparedTo)
        {
            var result = compareThis.CompareTo(comparedTo);
            return result >= 0;
        }

        public static bool IsEqualTo<T>(this IComparable<T> compareThis, T comparedTo)
            where T : IComparable<T>
        {
            var result = compareThis.CompareTo(comparedTo);
            return result == 0;
        }

        public static bool IsNotEqualTo<T>(this IComparable<T> compareThis, T comparedTo)
        {
            var result = compareThis.CompareTo(comparedTo);
            return result != 0;
        }
    }
}

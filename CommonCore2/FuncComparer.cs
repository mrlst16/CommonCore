using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CommonCore2
{
    public class FuncComparer<T> : IEqualityComparer<T>
    {

        public Func<T?, T?, bool> _expression;

        public FuncComparer(
            Func<T, T, bool> expression
            )
        {
            _expression = expression;
        }

        public bool Equals(T? x, T? y)
            => _expression(x, y);

        public int GetHashCode([DisallowNull] T obj)
            => obj.GetHashCode();

        public static implicit operator FuncComparer<T>(Func<T?, T?, bool> expression)
            => new FuncComparer<T>(expression);
    }
}

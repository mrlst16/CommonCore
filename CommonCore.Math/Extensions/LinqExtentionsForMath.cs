using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCore.Math.Extensions
{
    public struct Number
    {
        internal dynamic value;


        public static implicit operator Number(int val)
        {
            var result = new Number();
            result.value = val;
            return result;
        }

        public static implicit operator int(Number number)
            => number.value;

        public static implicit operator Number(double val)
        {
            var result = new Number();
            result.value = val;
            return result;
        }

        public static implicit operator double(Number number)
            => number.value;

        public static implicit operator Number(decimal val)
        {
            var result = new Number();
            result.value = val;
            return result;
        }

        public static implicit operator decimal(Number number)
            => number.value;

        public static implicit operator Number(float val)
        {
            var result = new Number();
            result.value = val;
            return result;
        }

        public static implicit operator float(Number number)
            => number.value;



        public static Number operator +(Number a, Number b)
        {
            var result = new Number();
            result.value = a.value + b.value;
            return result;
        }

        public static Number operator -(Number a, Number b)
        {
            var result = new Number();
            result.value = a.value - b.value;
            return result;
        }

        public static Number operator *(Number a, Number b)
        {
            var result = new Number();
            result.value = a.value * b.value;
            return result;
        }

        public static Number operator /(Number a, Number b)
        {
            var result = new Number();
            result.value = a.value / b.value;
            return result;
        }
    }

    public static class LinqExtentionsForMath
    {
        public static double Product(this IEnumerable<double> list)
            => list.Aggregate((x, y) => x * y);
        public static double Quotient(this IEnumerable<double> list)
                => list.Aggregate((x, y) => x / y);
        public static Number Sum(this IEnumerable<Number> list)
                       => list.Aggregate((x, y) => x + y);

    }
}

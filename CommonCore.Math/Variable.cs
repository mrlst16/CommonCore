using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Math
{
    public class Variable : IEnumerable<Variable>
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public IEnumerator<Variable> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator double(Variable variable)
            => variable.Value;
        public static implicit operator Variable(double number)
            => new Variable()
            {
                Name = "unspecified",
                Value = number
            };
    }

    public class VariableEnumerator : IEnumerator<Variable>
    {
        public Variable Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

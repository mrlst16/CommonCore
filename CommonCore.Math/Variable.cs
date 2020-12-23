using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Math
{
    public class Variable
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public Variable()
        {
        }

        public Variable(
            string name,
            double value
            )
        {
            Name = name;
            Value = value;
        }

        public static implicit operator double(Variable variable) => variable.Value;
        public static implicit operator Variable(double val) => new Variable("__unspecified_", val);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore.Math
{
    public abstract class FormulaBase
    {
        public string Name { get; set; }
        public IList<OperationBase> Operations { get; set; }

        public abstract Task<double> Evaluate();
    }
}

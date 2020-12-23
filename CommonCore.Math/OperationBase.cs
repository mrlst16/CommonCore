using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math
{
    public abstract class OperationBase : IOperation
    {
        public IList<IOperation> Children { get; set; } = new List<IOperation>();
        public IList<Variable> Variables { get; set; } = new List<Variable>();

        public abstract Task<double> Evaluate(ISubstitutionProvider substitutionProvider);

        public abstract Task<IOperation> Evaluate();
    }
}

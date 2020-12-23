using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math.Operations
{
    public class Add : OperationBase
    {
        public override async Task<double> Evaluate(ISubstitutionProvider substitutionProvider)
        {
            var result = Variables.Select(x => x.Value).Sum();

            Parallel.ForEach(Children, async (x) =>
            {
                var evaluation = await x.Evaluate(substitutionProvider);
                result += evaluation;
            });
            return result;
        }

        public override Task<IOperation> Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}

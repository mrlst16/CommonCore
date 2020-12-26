using CommonCore.Math.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math.Operations
{
    public class Divide : OperationBase
    {
        public async override Task<double> Evaluate(ISubstitutionProvider substitutionProvider)
        {
            var result = Variables.Select(x => x.Value).Quotient();

            Parallel.ForEach(Children, async (x) =>
            {
                var evaluation = await x.Evaluate(substitutionProvider);
                result *= evaluation;
            });
            return result;
        }

        public async override Task<IOperation> Factor()
        {
            throw new NotImplementedException();
        }
    }
}

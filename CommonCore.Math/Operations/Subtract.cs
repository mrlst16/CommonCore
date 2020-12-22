using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math.Operations
{
    public class Subtract : OperationBase
    {
        public override async Task<double> Evaluate()
        {
            var result = Variables.Aggregate((x, y) => x - y);

            Parallel.ForEach(Children, async (x) =>
            {
                var evaluation = await x.Evaluate();
                result -= evaluation;
            });
            return result;
        }
    }
}

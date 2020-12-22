using CommonCore.Math.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCore.Math.Operations
{
    public class Multiply: OperationBase
    {
        public override async Task<double> Evaluate()
        {
            var result = Variables.Select(x => x.Value).Product();

            Parallel.ForEach(Children, async (x) =>
            {
                var evaluation = await x.Evaluate();
                result *= evaluation;
            });
            return result;
        }
    }
}

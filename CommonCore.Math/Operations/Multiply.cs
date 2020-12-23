using CommonCore.Math.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCore.Math.Operations
{
    public class Multiply : OperationBase
    {
        public async override Task<double> Evaluate(ISubstitutionProvider substitutionProvider)
        {
            var result = Variables.Select(x => x.Value).Product();

            Parallel.ForEach(Children, async (x) =>
            {
                var evaluation = await x.Evaluate(substitutionProvider);
                result *= evaluation;
            });
            return result;
        }

        public override Task<IOperation> Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}

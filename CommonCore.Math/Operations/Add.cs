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

        public async override Task<IOperation> Factor()
        {
            List<IOperation> factoredChildren = Children
                .Select(async x =>
                {
                    var res = (await x.Factor());
                    return res;
                })
                .Select(x => x.Result)
                .ToList();
            var factoredVariables = new List<Variable>();
            
            for (int i = 0; i < Variables.Count; i++)
            {
                for (int j = 0; j < Variables.Count; j++)
                {
                    if (i == j) continue;

                }
            }
            return new Add()
            {
                Variables = factoredVariables,
                Children = factoredChildren
            };
        }
    }
}

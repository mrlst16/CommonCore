using CommonCore.Interfaces.RuleTrees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class RuleTreeAssembler : IRuleTreeAssembler
    {

        private readonly IRuleTreeValueProvider _ruleTreeValueProvider;

        public RuleTreeAssembler(
            IRuleTreeValueProvider ruleTreeValueProvider
            )
        {
            _ruleTreeValueProvider = ruleTreeValueProvider;
        }

        public async Task Assemble(IRuleTree ruleTree)
        {
            await Assemble(ruleTree.BaseNode.Children);
        }

        private async Task Assemble(IEnumerable<IRuleNode> children)
        {

            foreach (var child in children)
            {
                if (child is SearchParameterRule rule)
                {
                    rule.ParentID = child.ID;
                    rule.ComparisonValue = await _ruleTreeValueProvider.GetValue(rule.Key);
                }

                await Assemble(child.Children);
            }
        }
    }
}

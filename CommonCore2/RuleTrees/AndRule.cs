using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class AndRule : RuleNode
    {
        public AndRule()
            : base() { }

        public AndRule(params RuleNode[] ruleNodes)
            : base(ruleNodes) { }

        public async override Task<bool> Passes()
            => await RuleTree.PassesAnd(Children);
    }
}

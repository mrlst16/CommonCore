using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class OrRule : RuleNode
    {
        public OrRule()
            : base() { }

        public OrRule(params RuleNode[] ruleNodes)
            : base(ruleNodes) { }

        public async override Task<bool> Passes()
            => await RuleTree.PassesOr(Children);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees
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

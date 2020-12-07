using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees
{
    public class OptionsSearchParameter<T> : SearchParameterRule<T>
    {
        public List<T> Set { get; set; }
        public T Value { get; set; }

        public override async Task<bool> Passes()
        {
            var result = Set.Contains(Value);
            return result && await RuleTree.PassesAnd(Children);
        }
    }
}

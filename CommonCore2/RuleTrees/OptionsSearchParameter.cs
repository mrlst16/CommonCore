using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class OptionsSearchParameter<T> : SearchParameterRule
    {
        public List<T> Set { get; set; }

        public override async Task<bool> Passes()
        {
            bool result = false;
            if (ComparisonValue is T comparisonValue)
            {
                result = Set?.Contains(comparisonValue) ?? false;
            }
            return result && await RuleTree.PassesAnd(Children);
        }

        public OptionsSearchParameter() : base()
        {
        }
    }
}

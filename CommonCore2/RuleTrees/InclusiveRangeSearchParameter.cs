using CommonCore.Models.Extensions;
using System;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class InclusiveRangeSearchParameter : SearchParameterRule
    {
        public IComparable From { get; set; }
        public IComparable To { get; set; }

        public async override Task<bool> Passes()
        {
            bool result = false;
            if (ComparisonValue is IComparable comparisonValue)
            {
                result = comparisonValue.IsGreaterThanOrEqualTo(From)
                && comparisonValue.IsLessThanOrEqualTo(To);
            }

            return result && await RuleTree.PassesAnd(Children);
        }
    }

    public class InclusiveRangeSearchParameter<T> : SearchParameterRule
    {
        public T From { get; set; }
        public T To { get; set; }

        public async override Task<bool> Passes()
        {
            bool result = false;
            if (ComparisonValue is IComparable<T> comparisonValue)
            {
                result = comparisonValue.IsGreaterThanOrEqualTo(From)
                && comparisonValue.IsLessThanOrEqualTo(To);
            }

            return result && await RuleTree.PassesAnd(Children);
        }
    }
}

using CommonCore.Models.Extensions;
using CommonCore2.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class ExclusiveRangeSearchParameter : SearchParameterRule
    {
        public IComparable From { get; set; }
        public IComparable To { get; set; }

        public async override Task<bool> Passes()
        {
            bool result = false;
            if (ComparisonValue is IComparable comparisonValue)
            {
                result = comparisonValue.IsGreaterThan(From)
                && comparisonValue.IsLessThan(To);
            }

            return result && await RuleTree.PassesAnd(Children);
        }
    }

    public class ExclusiveRangeSearchParameter<T> : SearchParameterRule
    {
        public T From { get; set; }
        public T To { get; set; }

        public async override Task<bool> Passes()
        {
            bool result = false;
            if (ComparisonValue is IComparable<T> comparisonValue)
            {
                result = comparisonValue.IsGreaterThan(From)
                && comparisonValue.IsLessThan(To);
            }

            return result && await RuleTree.PassesAnd(Children);
        }
    }
}

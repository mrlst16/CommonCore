﻿using CommonCore.Models.Extensions;
using CommonCore2.RuleTrees.Comparison;
using System;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class InclusiveRangeSearchParameter<T2> : ComparisonRule<T2>
        where T2 : IComparable<T2>
    {
        public T2 From { get; set; }
        public T2 To { get; set; }

        public async override Task<bool> Passes()
        {
            bool result = false;
            if (ComparisonValue is T2 comparisonValue)
            {
                result = comparisonValue.IsGreaterThanOrEqualTo(From)
                && comparisonValue.IsLessThanOrEqualTo(To);
            }

            return result && await RuleTree.PassesAnd(Children);
        }
    }
}

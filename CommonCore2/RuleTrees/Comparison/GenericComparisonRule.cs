using CommonCore.Models.Enums;
using CommonCore.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees.Comparison
{
    public class GenericComparisonRule<T2> : ComparisonRule<T2>
        where T2 : IComparable<T2>
    {

        public GenericComparisonRule() : base()
        {
        }

        public GenericComparisonRule(T2 comparisonValue) : base(comparisonValue)
        {
        }

        public GenericComparisonRule(T2 ownValue, T2 comparisonValue) : base(ownValue, comparisonValue)
        {
        }

        public async override Task<bool> Passes()
        {
            bool result = false;

            if (ComparisonValue is T2 comparisonValue)
            {
                switch (Operator)
                {
                    case ComparisonOperatorEnum.LessThan:
                        result = OwnValue.IsLessThan<T2>(comparisonValue);
                        break;
                    case ComparisonOperatorEnum.LessThanOrEqualTo:
                        result = OwnValue.IsLessThanOrEqualTo<T2>(comparisonValue);
                        break;
                    case ComparisonOperatorEnum.EqualTo:
                        result = OwnValue.IsEqualTo<T2>(comparisonValue);
                        break;
                    case ComparisonOperatorEnum.GreaterThanOrEqualTo:
                        result = OwnValue.IsGreaterThanOrEqualTo<T2>(comparisonValue);
                        break;
                    case ComparisonOperatorEnum.GreaterThan:
                        result = OwnValue.IsGreaterThan<T2>(comparisonValue);
                        break;
                    case ComparisonOperatorEnum.NotEqualTo:
                        result = OwnValue.IsNotEqualTo<T2>(comparisonValue);
                        break;
                    default:
                        result = OwnValue.IsEqualTo<T2>(comparisonValue);
                        break;
                }
            }
            return result
                && await RuleTree.PassesAnd(Children);
        }
    }
}

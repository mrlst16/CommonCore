using CommonCore.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees.Comparison
{
    public class GenericComparisonRule<T2> : ComparisonRule<T2>
        where T2 : IComparable<T2>
    {
        public async override Task<bool> Passes()
        {
            switch (Operator)
            {
                case Enums.ComparisonOperatorEnum.LessThan:
                    return OwnValue.IsLessThan<T2>(ComparisonValue);
                case Enums.ComparisonOperatorEnum.LessThanOrEqualTo:
                    return OwnValue.IsLessThanOrEqualTo<T2>(ComparisonValue);
                case Enums.ComparisonOperatorEnum.EqualTo:
                    return OwnValue.IsEqualTo<T2>(ComparisonValue);
                case Enums.ComparisonOperatorEnum.GreaterThanOrEqualTo:
                    return OwnValue.IsGreaterThanOrEqualTo<T2>(ComparisonValue);
                case Enums.ComparisonOperatorEnum.GreaterThan:
                    return OwnValue.IsGreaterThan<T2>(ComparisonValue);
                case Enums.ComparisonOperatorEnum.NotEqualTo:
                    return OwnValue.IsNotEqualTo<T2>(ComparisonValue);
                default:
                    return OwnValue.IsEqualTo<T2>(ComparisonValue);
            }
        }
    }
}

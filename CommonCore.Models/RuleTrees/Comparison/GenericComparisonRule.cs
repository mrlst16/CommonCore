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
            var value = OwnValue.CompareTo(ComparisonValue);

            switch (Operator)
            {
                case Enums.ComparisonOperatorEnum.LessThan:
                    return value < 0;
                case Enums.ComparisonOperatorEnum.LessThanOrEqualTo:
                    return value < 0 || value == 0;
                case Enums.ComparisonOperatorEnum.EqualTo:
                    return value == 0;
                case Enums.ComparisonOperatorEnum.GreaterThanOrEqualTo:
                    return value > 0 || value == 0;
                case Enums.ComparisonOperatorEnum.GreaterThan:
                    return value > 0;
                default:
                    return value == 0;
            }
        }
    }
}

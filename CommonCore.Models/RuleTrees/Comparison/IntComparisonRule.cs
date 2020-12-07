using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees.Comparison
{
    public class IntComparisonRule : ComparisonRule<int>
    {
        public async override Task<bool> Passes()
        {
            var result = false;
            switch (Operator)
            {
                case CommonCore.Models.Enums.ComparisonOperatorEnum.LessThan:
                    result = OwnValue < ComparisonValue;
                    break;
                case CommonCore.Models.Enums.ComparisonOperatorEnum.LessThanOrEqualTo:
                    result = OwnValue >= ComparisonValue;
                    break;
                case CommonCore.Models.Enums.ComparisonOperatorEnum.EqualTo:
                    result = OwnValue == ComparisonValue;
                    break;
                case CommonCore.Models.Enums.ComparisonOperatorEnum.GreaterThanOrEqualTo:
                    result = OwnValue >= ComparisonValue;
                    break;
                case CommonCore.Models.Enums.ComparisonOperatorEnum.GreaterThan:
                    result = OwnValue >= ComparisonValue;
                    break;
                case CommonCore.Models.Enums.ComparisonOperatorEnum.NotEqualTo:
                    result = OwnValue != ComparisonValue;
                    break;
                default:
                    result = OwnValue == ComparisonValue;
                    break;
            }
            return result && await RuleTree.PassesAnd(Children);
        }
    }

    
}

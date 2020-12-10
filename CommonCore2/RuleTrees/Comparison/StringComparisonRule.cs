using System.Threading.Tasks;

namespace CommonCore2.RuleTrees.Comparison
{
    public class StringComparisonRule : ComparisonRule<string>
    {
        private const string NonApplicableOperatorMessage = "Only equals and not-equals operators are valid for StringComparisonRule";

        public async override Task<bool> Passes()
        {
            var result = false;

            switch (Operator)
            {
                case CommonCore.Models.Enums.ComparisonOperatorEnum.LessThan:
                case CommonCore.Models.Enums.ComparisonOperatorEnum.LessThanOrEqualTo:
                case CommonCore.Models.Enums.ComparisonOperatorEnum.GreaterThanOrEqualTo:
                case CommonCore.Models.Enums.ComparisonOperatorEnum.GreaterThan:
                    throw new System.Exception(NonApplicableOperatorMessage);
                case CommonCore.Models.Enums.ComparisonOperatorEnum.EqualTo:
                    result = OwnValue == ComparisonValue;
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

        public StringComparisonRule() : base()
        {

        }

        public StringComparisonRule(string comparisonValue) : base(comparisonValue) { }

        public StringComparisonRule(string ownValue, string comparisonValue) : base(ownValue, comparisonValue)
        {
        }
    }
}

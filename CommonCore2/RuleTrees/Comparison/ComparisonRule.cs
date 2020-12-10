using CommonCore.Models.Enums;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees.Comparison
{
    public abstract class ComparisonRule<T> : SearchParameterRule
    {
        public string Type { get; set; }
        public T OwnValue { get; set; }

        public ComparisonOperatorEnum Operator { get; set; }

        protected ComparisonRule() : base()
        {
        }

        protected ComparisonRule(T comparisonValue)
        {
            ComparisonValue = comparisonValue;
        }

        protected ComparisonRule(T ownValue, T comparisonValue)
        {
            OwnValue = ownValue;
            ComparisonValue = comparisonValue;
        }
    }
}

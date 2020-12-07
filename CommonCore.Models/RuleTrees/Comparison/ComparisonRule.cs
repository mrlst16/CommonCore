using CommonCore.Models.Enums;

namespace CommonCore.Models.RuleTrees.Comparison
{
    public abstract class ComparisonRule<T> : SearchParameterRule<T>
    {
        public T OwnValue { get; set; }
        public T ComparisonValue { get; set; }

        public ComparisonOperatorEnum Operator { get; set; }

        public ComparisonRule<T> CompareTo(T otherVaue)
        {
            this.ComparisonValue = otherVaue;
            return this;
        }

        public ComparisonRule() : base()
        {
        }

        public ComparisonRule(T comparisonValue)
        {
            ComparisonValue = comparisonValue;
        }

        public ComparisonRule(T ownValue, T comparisonValue)
        {
            OwnValue = ownValue;
            ComparisonValue = comparisonValue;
        }
    }
}

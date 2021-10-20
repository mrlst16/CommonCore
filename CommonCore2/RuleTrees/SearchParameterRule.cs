namespace CommonCore2.RuleTrees
{
    public abstract class SearchParameterRule : RuleNode
    {
        public string Key { get; set; }
        public object ComparisonValue { get; set; }

        public SearchParameterRule()
        {

        }
    }
}

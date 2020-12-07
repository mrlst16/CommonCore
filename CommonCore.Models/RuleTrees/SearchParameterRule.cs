using CommonCore.Models.RuleTrees;

namespace CommonCore.Models.RuleTrees
{
    public abstract class SearchParameterRule<T> : RuleNode
    {
        public string Type { get; set; }
        public string Key { get; set; }

        public SearchParameterRule()
        {
        }
    }
}

using CommonCore.Interfaces.RuleTrees;
using CommonCore2.RuleTrees;
using CommonCore2.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Tests.MockData
{
    public static class RuleTreeMockData
    {

        public static IRuleTree AgeAndLikes_GeneticsAndName => new RuleTree()
        {
            BaseNode = new AndRule()
            {
                Children = new List<IRuleNode>()
                    {
                        new GenericComparisonRule<int>(1){
                            Key = "Age"
                        },
                        new GenericComparisonRule<int>(1){
                            Key = "Likes",
                            Children = new List<IRuleNode>()
                            {
                                new OrRule()
                                {
                                    Children = new List<IRuleNode>()
                                    {
                                        new OptionsSearchParameter<string>()
                                        {
                                            Key = "Genetics",
                                            Set = new List<string>(){ "white", "black"}
                                        },
                                        new GenericComparisonRule<string>()
                                        {
                                            Key = "Name",
                                            ComparisonValue = "Phil"
                                        }
                                    }
                                }
                            }
                        }
                    }
            }

        };

        public static AndRule AndRuleNoChildren => new AndRule() { };
        public static OrRule OrRuleNoChildren => new OrRule() { };

        public static IRuleTree OrRuleTwoStringComparisonRules_BothMatch => new RuleTree()
        {
            BaseNode = new OrRule()
            {
                Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dog")
                    }
            }
        };

        public static IRuleTree OrRuleTwoStringComparisonRules_OneMatch => new RuleTree()
        {
            BaseNode = new OrRule()
            {
                Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joes", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dog")
                    }
            }
        };

        public static IRuleTree OrRuleTwoStringComparisonRules_NoneMatch => new RuleTree()
        {
            BaseNode = new OrRule()
            {
                Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joes", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dog")
                    }
            }
        };

        public static IRuleTree AndRuleTwoStringComparisonRules_BothMatch => new RuleTree()
        {
            BaseNode = new AndRule()
            {
                Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dog")
                    }
            }
        };

        public static IRuleTree AndRuleTwoStringComparisonRules_OnehMatch => new RuleTree()
        {
            BaseNode = new AndRule()
            {
                Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joes", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dog")
                    }
            }
        };

        public static IEnumerable<IRuleNode> TwoStringComparisons_BothMatch = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dog")
                    };

        public static IEnumerable<IRuleNode> TwoStringComparisons_OneMatch = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dogs", "Dog")
                    };

        public static IEnumerable<IRuleNode> FiveStringComparisons_FourMatch = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dogs", "Dog")
                    };

        public static IEnumerable<IRuleNode> FiveStringComparisons_OneMatch = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dogs", "Dog"),
                        new GenericComparisonRule<string>("Dogs", "Dog"),
                        new GenericComparisonRule<string>("Dogs", "Dog"),
                        new GenericComparisonRule<string>("Dogs", "Dog")
                    };

        public static IEnumerable<IRuleNode> GenerateStringComparsons(int matches, int nonMatches)
        {
            var result = new List<IRuleNode>();
            for (int i = 0; i < matches; i++)
            {
                result.Add(new GenericComparisonRule<string>("Joe", "Joe"));
            }
            for (int i = 0; i < nonMatches; i++)
            {
                result.Add(new GenericComparisonRule<string>("Dogs", "Dog"));
            }
            return result;
        }

    }
}

using CommonCore.Interfaces.RuleTrees;
using CommonCore.Tests.MockData;
using CommonCore2.RuleTrees;
using CommonCore2.RuleTrees.Comparison;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.RuleTrees
{
    public class RuleTreeTests
    {
        [Fact]
        public async Task Passes_TwoStringComparsionValues_And_PassesTrue()
        {
            RuleTree ruleTree = new RuleTree()
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

            Assert.True(await ruleTree.Passes());
        }

        [Fact]
        public async Task Passes_TwoStringComparsionValues_And_PassesFalse()
        {
            RuleTree ruleTree = new RuleTree()
            {
                BaseNode = new AndRule()
                {
                    Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dogs")
                    }
                }
            };

            Assert.False(await ruleTree.Passes());
        }

        [Fact]
        public async Task Passes_TwoStringComparsionValues_Or_PassesTrue()
        {
            RuleTree ruleTree = new RuleTree()
            {
                BaseNode = new OrRule()
                {
                    Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joe", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dogs")
                    }
                }
            };

            Assert.True(await ruleTree.Passes());
        }

        [Fact]
        public async Task Passes_TwoStringComparsionValues_Or_PassesFalse()
        {
            RuleTree ruleTree = new RuleTree()
            {
                BaseNode = new OrRule()
                {
                    Children = new List<RuleNode>()
                    {
                        new GenericComparisonRule<string>("Joes", "Joe"),
                        new GenericComparisonRule<string>("Dog", "Dogs")
                    }
                }
            };

            Assert.False(await ruleTree.Passes());
        }

        [Fact]
        public async Task PassesAnd_NoChildren_True()
        {
            var result = await RuleTree.PassesAnd<IRuleNode>(RuleTreeMockData.AndRuleNoChildren.Children);
            Assert.True(result);
        }

        [Fact]
        public async Task PassesAnd_TwoStringComparsionValues_True()
        {
            var result = await RuleTree.PassesAnd(RuleTreeMockData.AndRuleTwoStringComparisonRules_BothMatch.BaseNode.Children);
            Assert.True(result);
        }

        [Fact]
        public async Task PassesOr_NoChildren_False()
        {
            var result = await RuleTree.PassesOr<IRuleNode>(RuleTreeMockData.AndRuleNoChildren.Children);
            Assert.False(result);
        }

        [Fact]
        public async Task PassesOr_TwoStringComparsionValues_True()
        {
            var result = await RuleTree.PassesOr(RuleTreeMockData.AndRuleTwoStringComparisonRules_BothMatch.BaseNode.Children);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0, 1, false)]
        [InlineData(1, 0, 1, false)]
        [InlineData(1, 1, 1, true)]
        [InlineData(2, 1, 1, true)]
        [InlineData(4, 1, 1, false)]
        public async Task PassesLimitNotAllPass_Theory(int matches, int nonMatches, int limit, bool expected)
        {
            var result = await RuleTree.PassesLimitNotAllPass(RuleTreeMockData.TwoStringComparisons_BothMatch, 1);
            Assert.False(result);
        }
    }
}

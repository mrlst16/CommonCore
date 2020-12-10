using CommonCore2.RuleTrees;
using CommonCore2.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

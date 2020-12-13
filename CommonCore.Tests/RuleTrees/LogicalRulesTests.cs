using CommonCore.Tests.MockData;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.RuleTrees
{
    public class LogicalRulesTests
    {

        [Fact]
        public async Task AndRule_NoChildren_DoesNotPass()
        {
            var rule = RuleTreeMockData.AndRuleNoChildren;
            var result = await rule.Passes();
            Assert.True(result);
        }

        [Fact]
        public async Task AndRule_TwoStringComparisonRulesBothMatch_Passes()
        {
            var rule = RuleTreeMockData.AndRuleTwoStringComparisonRules_BothMatch;
            var result = await rule.Passes();
            Assert.True(result);
        }

        [Fact]
        public async Task AndRule_TwoStringComparisonRulesBothMatch_DoesNotPass()
        {
            var rule = RuleTreeMockData.AndRuleTwoStringComparisonRules_OnehMatch;
            var result = await rule.Passes();
            Assert.False(result);
        }

        [Fact]
        public async Task OrRule_NoChildren_DoesNotPass()
        {
            var rule = RuleTreeMockData.OrRuleNoChildren;
            var result = await rule.Passes();
            Assert.False(result);
        }

        [Fact]
        public async Task OrRule_TwoStringComparisonRulesBothMatch_Passes()
        {
            var rule = RuleTreeMockData.OrRuleTwoStringComparisonRules_BothMatch;
            var result = await rule.Passes();
            Assert.True(result);
        }

        [Fact]
        public async Task OrRule_TwoStringComparisonRulesOneMatch_Passes()
        {
            var rule = RuleTreeMockData.OrRuleTwoStringComparisonRules_OneMatch;
            var result = await rule.Passes();
            Assert.True(result);
        }

        [Fact]
        public async Task OrRule_TwoStringComparisonRulesNoneMatch_DoesNotPasses()
        {
            var rule = RuleTreeMockData.OrRuleTwoStringComparisonRules_OneMatch;
            var result = await rule.Passes();
            Assert.True(result);
        }
    }
}

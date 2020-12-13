using CommonCore2.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.RuleTrees
{
    public class GenericComparisonRuleTests
    {


        [Theory]
        [InlineData("one", "two")]
        [InlineData(1, 2)]
        [InlineData(1.1, 2.2)]
        [InlineData('c', 'v')]
        public async Task Passes_False<T>(IComparable one, IComparable two)
        {
            GenericComparisonRule rule = new GenericComparisonRule(one, two);
            var result = await rule.Passes();
            Assert.False(result);
        }

        [Theory]
        [InlineData("one", "one")]
        [InlineData(1, 1)]
        [InlineData(1.1, 1.1)]
        [InlineData('c', 'c')]
        public async Task Passes_True<T>(IComparable one, IComparable two)
        {
            GenericComparisonRule rule = new GenericComparisonRule(one, two);
            var result = await rule.Passes();
            Assert.True(result);
        }

        [Theory]
        [InlineData("one", '6')]
        [InlineData(1, '4')]
        [InlineData(1, 1.1)]
        [InlineData('c', 1.1)]
        public async Task Passes_TypeMismatch_ExceptionThrown<T>(IComparable one, IComparable two)
        {
            GenericComparisonRule rule = new GenericComparisonRule(one, two);
            await Assert.ThrowsAnyAsync<Exception>(async () => await rule.Passes());
        }

    }
}

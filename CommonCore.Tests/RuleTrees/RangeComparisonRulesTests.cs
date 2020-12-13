using CommonCore2.RuleTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.RuleTrees
{
    public class RangeComparisonRulesTests
    {

        [Theory]
        [InlineData(1, 2, 3, false)]
        [InlineData(2, 6, 4, true)]
        [InlineData(1, 2, 2, false)]
        [InlineData(2, 6, 2, false)]
        public async Task Exclusive_Passes_int(int from, int to, int value, bool expected)
        {
            var rule = new ExclusiveRangeSearchParameter<int>()
            {
                From = from,
                To = to,
                ComparisonValue = value
            };

            var result = await rule.Passes();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 3, false)]
        [InlineData(2, 6, 4, true)]
        [InlineData(1, 2, 2, false)]
        [InlineData(2, 6, 2, false)]
        [InlineData(2.0, 3.5, 4.5, false)]
        [InlineData(2.0, 6.0, 4.6, true)]
        [InlineData(2.0, 3.5, 2.0, false)]
        [InlineData(2.0, 6.0, 6.0, false)]
        public async Task Exclusive_Passes_ICopmarable(IComparable from, IComparable to, IComparable value, bool expected)
        {
            var rule = new ExclusiveRangeSearchParameter()
            {
                From = from,
                To = to,
                ComparisonValue = value
            };

            var result = await rule.Passes();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 3, false)]
        [InlineData(2, 6, 4, true)]
        [InlineData(1, 2, 2, true)]
        [InlineData(2, 6, 2, true)]
        public async Task Inclusive_Passes_int(int from, int to, int value, bool expected)
        {
            var rule = new InclusiveRangeSearchParameter<int>()
            {
                From = from,
                To = to,
                ComparisonValue = value
            };

            var result = await rule.Passes();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 3, false)]
        [InlineData(2, 6, 4, true)]
        [InlineData(1, 2, 2, true)]
        [InlineData(2, 6, 2, true)]
        [InlineData(2.0, 3.5, 4.5, false)]
        [InlineData(2.0, 6.0, 4.6, true)]
        [InlineData(2.0, 3.5, 2.0, true)]
        [InlineData(2.0, 6.0, 6.0, true)]
        public async Task Inclusive_Passes_ICopmarable(IComparable from, IComparable to, IComparable value, bool expected)
        {
            var rule = new InclusiveRangeSearchParameter()
            {
                From = from,
                To = to,
                ComparisonValue = value
            };

            var result = await rule.Passes();

            Assert.Equal(expected, result);
        }
    }
}

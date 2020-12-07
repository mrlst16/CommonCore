using CommonCore.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.Extensions
{
    public class IComparableExtensionsTests
    {
        [Theory]
        [InlineData(3, 5, true)]
        [InlineData(5, 5, false)]
        [InlineData(7, 5, false)]
        public async Task IsLessThan(int compareThis, int compareTo, bool expectedResult)
        {
            var result = compareThis.IsLessThan(compareTo);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(7, 5, false)]
        public async Task IsLessThanOrEqualTo(int compareThis, int compareTo, bool expectedResult)
        {
            var result = compareThis.IsLessThanOrEqualTo(compareTo);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 5, false)]
        [InlineData(5, 5, true)]
        [InlineData(7, 5, true)]
        public async Task IsGreaterThanOrEqualTo(int compareThis, int compareTo, bool expectedResult)
        {
            var result = compareThis.IsGreaterThanOrEqualTo(compareTo);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 5, false)]
        [InlineData(5, 5, false)]
        [InlineData(7, 5, true)]
        public async Task IsGreaterThan(int compareThis, int compareTo, bool expectedResult)
        {
            var result = compareThis.IsGreaterThan(compareTo);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 5, false)]
        [InlineData(5, 5, true)]
        [InlineData(7, 5, false)]
        public async Task IsEqualTo(int compareThis, int compareTo, bool expectedResult)
        {
            var result = compareThis.IsEqualTo(compareTo);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 5, true)]
        [InlineData(5, 5, false)]
        [InlineData(7, 5, true)]
        public async Task IsNotEqualTo(int compareThis, int compareTo, bool expectedResult)
        {
            var result = compareThis.IsNotEqualTo(compareTo);
            Assert.Equal(expectedResult, result);
        }
    }
}

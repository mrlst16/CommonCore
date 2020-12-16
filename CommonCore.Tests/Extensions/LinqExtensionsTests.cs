using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using CommonCore.Standard.Extensions;

namespace CommonCore.Tests.Extensions
{
    public class LinqExtensionsTests
    {

        [Fact]
        public void None_NotEmpty_ShouldReturnFalse()
        {
            List<int> request = new List<int>() { 1 };
            var result = request.None();
            Assert.False(result);
        }

        [Fact]
        public void None_Null_ShouldReturnTrue()
        {
            List<int> request = null;
            var result = request.None();
            Assert.True(result);
        }

        [Fact]
        public void None_Empty_ShouldReturnTrue()
        {
            List<int> request = new List<int>() { };
            var result = request.None();
            Assert.True(result);
        }

        [Fact]
        public void NoneWithPredicate_NotEmpty_ShouldReturnFalse()
        {
            List<int> request = new List<int>() { 1 };
            var result = request.None(x => true);
            Assert.False(result);
        }

        [Fact]
        public void NoneWithPredicate_Null_ShouldReturnTrue()
        {
            List<int> request = null;
            var result = request.None(x => true);
            Assert.True(result);
        }

        [Fact]
        public void NoneWithPredicate_Empty_ShouldReturnTrue()
        {
            List<int> request = new List<int>() { };
            var result = request.None(x => true);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 8, 9)]
        public void RangeBetweenInclusive_Empty_CorrectCount(int start, int end, int expectedCount)
        {
            List<int> request = new List<int>()
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8
            };
            var result = request.RangeBetweenInclusive(start, end);
            Assert.Equal(expectedCount, result.Count());
        }
    }
}

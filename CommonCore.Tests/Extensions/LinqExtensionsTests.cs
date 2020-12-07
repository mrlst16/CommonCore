using CommonCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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
            var result = request.None(x=> true);
            Assert.False(result);
        }

        [Fact]
        public void NoneWithPredicate_Null_ShouldReturnTrue()
        {
            List<int> request = null;
            var result = request.None(x=> true);
            Assert.True(result);
        }

        [Fact]
        public void NoneWithPredicate_Empty_ShouldReturnTrue()
        {
            List<int> request = new List<int>() { };
            var result = request.None(x=> true);
            Assert.True(result);
        }
    }
}

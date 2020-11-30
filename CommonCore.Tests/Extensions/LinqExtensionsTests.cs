using CommonCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Tests.Extensions
{
    [TestClass]
    public class LinqExtensionsTests
    {

        [TestMethod]
        public void None_NotEmpty_ShouldReturnFalse()
        {
            List<int> request = new List<int>() { 1 };
            var result = request.None();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void None_Null_ShouldReturnTrue()
        {
            List<int> request = null;
            var result = request.None();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void None_Empty_ShouldReturnTrue()
        {
            List<int> request = new List<int>() { };
            var result = request.None();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NoneWithPredicate_NotEmpty_ShouldReturnFalse()
        {
            List<int> request = new List<int>() { 1 };
            var result = request.None(x=> true);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NoneWithPredicate_Null_ShouldReturnTrue()
        {
            List<int> request = null;
            var result = request.None(x=> true);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NoneWithPredicate_Empty_ShouldReturnTrue()
        {
            List<int> request = new List<int>() { };
            var result = request.None(x=> true);
            Assert.IsTrue(result);
        }
    }
}

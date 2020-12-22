using CommonCore.Math.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Math.Test.Operations
{
    public class DivideTests
    {
        [Theory]
        [InlineData(3, 3, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(1000, 100, 10)]
        public async Task Evaluate_2V1L_Theory(double one, double two, double expected)
        {
            var op = new Divide()
            {
                Variables = new List<Variable>()
                {
                    one,
                    two
                }
            };
            var result = await op.Evaluate();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(27, 3, 3, 3)]
        [InlineData(0, 1, 1, 0)]
        [InlineData(10000, 10, 10, 100)]
        public async Task Evaluate_3V1L_Theory(double one, double two, double three, double expected)
        {
            var op = new Divide()
            {
                Variables = new List<Variable>()
                {
                    one,
                    two,
                    three
                }
            };
            var result = await op.Evaluate();
            Assert.Equal(expected, result);
        }

    }
}

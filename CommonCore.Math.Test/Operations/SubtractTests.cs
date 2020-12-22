using CommonCore.Math.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Math.Test.Operations
{
    public class SubtractTests
    {
        [Theory]
        [InlineData(3, 3, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(10, 10, 0)]
        public async Task Evaluate_2V1L_Theory(double one, double two, double expected)
        {
            var op = new Subtract()
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
        [InlineData(3, 3, 3, -3)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 1, 0, -1)]
        [InlineData(10, 10, 10, -10)]
        public async Task Evaluate_3V1L_Theory(double one, double two, double three, double expected)
        {
            var op = new Subtract()
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

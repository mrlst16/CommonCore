using CommonCore.Math.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Math.Test.Operations
{
    public class MultiplyTests
    {
        [Theory]
        [InlineData(3, 3, 9)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(10, 10, 100)]
        public async Task Evaluate_2V1L_Theory(double one, double two, double expected)
        {
            var op = new Multiply()
            {
                Variables = new List<Variable>()
                {
                    one,
                    two
                }
            };
            var subProvider = new DictionarySubstitutionProvider(new Dictionary<string, double>()
            {
                { "__unspecified__", 1}
            });

            var result = await op.Evaluate(subProvider);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 3, 3, 27)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(10, 10, 10, 1000)]
        public async Task Evaluate_3V1L_Theory(double one, double two, double three, double expected)
        {
            var op = new Multiply()
            {
                Variables = new List<Variable>()
                {
                    one,
                    two,
                    three
                }
            };
            var subProvider = new DictionarySubstitutionProvider(new Dictionary<string, double>()
            {
                { "__unspecified__", 1}
            });

            var result = await op.Evaluate(subProvider);
            Assert.Equal(expected, result);
        }

    }
}

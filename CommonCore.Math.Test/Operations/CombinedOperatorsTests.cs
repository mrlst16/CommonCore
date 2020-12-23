using CommonCore.Math.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Math.Test.Operations
{
    public class CombinedOperatorsTests
    {

        [Fact]
        public async Task Add4To5MultipyBy3_Expect27()
        {
            var op = new Multiply()
            {
                Children = new List<IOperation>() {
                    new Add() {
                        Variables = new List<Variable>() {
                            new Variable() { Name = "x", Value = 4 },
                            new Variable() { Name = "x", Value = 5 }
                        }
                    }
                },
                Variables = new List<Variable>()
                {
                    new Variable("x", 3)
                }
            };
            var subProvider = new DictionarySubstitutionProvider(new Dictionary<string, double>()
            {
                { "__unspecified__", 1}
            });

            var result = await op.Evaluate(subProvider);
            Assert.Equal(27, result);
        }
    }
}

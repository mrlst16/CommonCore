using CommonCore.Math.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Math.Test.Operations
{
    public class ExponentTests
    {
        [Fact]
        public async Task FourTo2_16()
        {
            var op = new Exponent()
            {
                Operation = new Add() { Variables = new List<Variable>() { 4 } },
                Power = 2
            };
            var subProvider = new DictionarySubstitutionProvider(new Dictionary<string, double>()
            {
                { "__unspecified__", 1}
            });

            var result = await op.Evaluate(subProvider);
            Assert.Equal(16, result);
        }
    }
}

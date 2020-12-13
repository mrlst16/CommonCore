using CommonCore2.RuleTrees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.RuleTrees
{
    public class OptionsSearchParameterTests
    {
        [Fact]
        public async Task Passes_ObjectNotAvailable_False()
        {
            var rule = new OptionsSearchParameter<string>()
            {
                Set = new List<string>()
                {
                    "white", "balck"
                },
                ComparisonValue = "blue"
            };
            var result = await rule.Passes();
            Assert.False(result);
        }

        [Fact]
        public async Task Passes_ObjecAvailable_True()
        {
            var rule = new OptionsSearchParameter<string>()
            {
                Set = new List<string>()
                {
                    "white", "balck"
                },
                ComparisonValue = "white"
            };
            var result = await rule.Passes();
            Assert.True(result);
        }
    }
}

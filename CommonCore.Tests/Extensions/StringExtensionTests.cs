using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using CommonCore.Standard.Extensions;

namespace CommonCore.Tests.Extensions
{
    public class StringExtensionTests
    {
        private List<string> Data = new List<string>()
        {
            "{{}} {}",
            "namespace Lab.Goodies { class F { } }  " + System.Environment.NewLine + "  namespace Lab.Goodies.Sweets { }",
            "{{{}}"
        };

        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 36)]
        public async Task IndexOfClosingCharacter_Theory_StartAt0_IndexEquals(int dataSet, int expectedIndex)
        {
            string input = Data[dataSet];
            var result = input.IndexOfClosingCharacter();
            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(0, 4, 6)]
        [InlineData(1, 37, 74)]
        public async Task IndexOfClosingCharacter_Theory_StartAtNext_IndexEquals(int dataSet, int startAt, int expectedIndex)
        {
            string input = Data[dataSet];
            int result = input.IndexOfClosingCharacter('{', '}', startAt);
            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public async Task Closes_Theory(int dataSet, bool expected)
        {
            string input = Data[dataSet];
            var result = input.Closes('{', '}');
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2)]
        public async Task MatchesCount_Theory(int dataSet, int expected)
        {
            string input = Data[dataSet];
            var result = input.MatchCount("namespace");
            Assert.Equal(expected, result);
        }


    }
}

using CommonCore.Interfaces.RuleTrees;
using CommonCore.Tests.MockData;
using CommonCore2.RuleTrees;
using CommonCore2.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.RuleTrees
{
    public class DictionaryRuleTreeAssemblerTests
    {


        [Fact]
        public async Task Passes_AllDataAvaliable_Passes()
        {
            var source = new Dictionary<string, object>()
            {
                { "Age", 1},
                { "Likes", 1},
                { "Genetics", "white"},
                { "Name", "Phil" }
            };

            IRuleTreeValueProvider valueProvider = new DictionaryValueProvider(source);

            IRuleTree tree = RuleTreeMockData.AgeAndLikes_GeneticsAndName;

            IRuleTreeAssembler assembler = new RuleTreeAssembler(valueProvider);
            await assembler.Assemble(tree);

            var result = await tree.Passes();
            Assert.True(result);
        }

        [Fact]
        public async Task Passes_AllDataAvaliable_ProperlyMatchesData()
        {
            var source = new Dictionary<string, object>()
            {
                { "Age", 1},
                { "Likes", 1},
                { "Genetics", "white"},
                { "Name", "Phil" }
            };

            IRuleTreeValueProvider valueProvider = new DictionaryValueProvider(source);

            IRuleTree tree = RuleTreeMockData.AgeAndLikes_GeneticsAndName;

            IRuleTreeAssembler assembler = new RuleTreeAssembler(valueProvider);
            await assembler.Assemble(tree);

            var ageNode = tree.BaseNode.Children.First() as GenericComparisonRule<int>;
            var likesNode = tree.BaseNode.Children.ElementAt(1) as GenericComparisonRule<int>;
            var geneticsNode = likesNode.Children.First().Children.First() as OptionsSearchParameter<string>;
            var nameNode = likesNode.Children.First().Children.ElementAt(1) as GenericComparisonRule<string>;

            Assert.Equal("Age", ageNode.Key);
            Assert.Equal(1, ageNode.ComparisonValue);
            Assert.Equal("Likes", likesNode.Key);
            Assert.Equal(1, likesNode.ComparisonValue);
            Assert.Equal("Genetics", geneticsNode.Key);
            Assert.Equal("white", geneticsNode.ComparisonValue);
            Assert.Equal("Name", nameNode.Key);
            Assert.Equal("Phil", nameNode.ComparisonValue);
        }


        [Fact]
        public async Task Passes_NotAllDataAvaliable_DoesNotPass()
        {
            var source = new Dictionary<string, object>()
            {
                { "Age", 1},
                { "Likes", 1}
            };

            IRuleTreeValueProvider valueProvider = new DictionaryValueProvider(source);

            IRuleTree tree = RuleTreeMockData.AgeAndLikes_GeneticsAndName;

            IRuleTreeAssembler assembler = new RuleTreeAssembler(valueProvider);
            await assembler.Assemble(tree);

            var result = await tree.Passes();
            Assert.False(result);
        }

        [Fact]
        public async Task Passes_NotAllDataAvaliable_DoesNotProperlyMatchesData()
        {
            var source = new Dictionary<string, object>()
            {
                { "Age", 1},
                { "Likes", 1},
                { "Genetics", "white"}
            };

            IRuleTreeValueProvider valueProvider = new DictionaryValueProvider(source);

            IRuleTree tree = RuleTreeMockData.AgeAndLikes_GeneticsAndName;

            IRuleTreeAssembler assembler = new RuleTreeAssembler(valueProvider);
            await assembler.Assemble(tree);
            var ageNode = tree.BaseNode.Children.First() as GenericComparisonRule<int>;
            var likesNode = tree.BaseNode.Children.ElementAt(1) as GenericComparisonRule<int>;
            var geneticsNode = likesNode.Children.First().Children.First() as OptionsSearchParameter<string>;
            var nameNode = likesNode.Children.First().Children.ElementAt(1) as GenericComparisonRule<string>;

            Assert.Equal("Age", ageNode.Key);
            Assert.Equal(1, ageNode.ComparisonValue);
            Assert.Equal("Likes", likesNode.Key);
            Assert.Equal(1, likesNode.ComparisonValue);
            Assert.Equal("Genetics", geneticsNode.Key);
            Assert.Equal("white", geneticsNode.ComparisonValue);
            Assert.Equal("Name", nameNode.Key);
            Assert.Null(nameNode.ComparisonValue);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CommonCore.Standard.Extensions;

namespace CommonCore.Tests.Extensions
{
    public class StringFileExtensionsTests
    {


        [Theory]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "one", @"one\two2")]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "two2", @"two2")]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "two1", @"two1\one\two2")]
        public async Task PathFromDeepestFolder_Theory(string input, string fromFolder, string expected)
        {
            var result = input.PathFromDeepestFolder(fromFolder);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "one", @"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one")]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "two2", @"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2")]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "two1", @"C:\Program Files\Microsoft Office 15\ClientX64\one\two1")]
        public async Task PathToDeepestFolder_Theory(string input, string fromFolder, string expected)
        {
            var result = input.PathToDeepestFolder(fromFolder);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "C:", "two2", @"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2")]
        [InlineData(@"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2", "Program Files", "two2", @"Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2")]
        public async Task PathBetweenFoldersToDeepestOccurrances_Theory(string input, string fromFolder, string endFolder, string expected)
        {
            var result = input.PathBetweenFoldersToDeepestOccurrances(fromFolder, endFolder);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Lab()
        {
            var input = @"C:\Program Files\Microsoft Office 15\ClientX64\one\two1\one\two2";

            var result = input.PathBetweenFoldersToDeepestOccurrances("Program Files", "two2");

        }
    }
}

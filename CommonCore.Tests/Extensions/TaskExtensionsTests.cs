using CommonCore2.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonCore.Tests.Extensions
{
    public class TaskExtensionsTests
    {
        [Theory]
        [InlineData(10, 2, 10)]
        [InlineData(100, 3, 100)]
        [InlineData(90, 1, 90)]
        public async Task FuncProcessInChunks_Theory(int size, int chunk, int expected)
        {
            List<int> data = new List<int>();
            for (int i = 0; i < size; i++)
            {
                data.Add(i);
            }
            Func<int, Task<string>> func = ToStringForInt;
            var results = await func.ProcessInChunks(data, chunk);
            Assert.Equal(expected, results.Count());
        }

        public async Task<string> ToStringForInt(int i) => i.ToString();
    }
}

using CommonCore2.Extensions;
using System;
using Xunit;

namespace CommonCore.Tests.Extensions
{
    public class GuidExtensionTetst
    {
        //6dae9971-5abc-4281-b6f0-ed9afe767db0
        //7e2e3852-6cfb-49a4-9fff-9311b908a8ad
        Guid one = new Guid("6dae9971-5abc-4281-b6f0-ed9afe767db0");
        Guid two = new Guid("7e2e3852-6cfb-49a4-9fff-9311b908a8ad");

        [Fact]
        public void Merge_OneAndTwo_ShouldBeOneFirst()
        {
            string expected = $"6dae9971-5abc-4281-b6f0-ed9afe767db0_7e2e3852-6cfb-49a4-9fff-9311b908a8ad";
            var result = one.Merge(two);
        }

        [Fact]
        public void Merge_TwoAndOne_ShouldBeOneFirst()
        {
            string expected = $"6dae9971-5abc-4281-b6f0-ed9afe767db0_7e2e3852-6cfb-49a4-9fff-9311b908a8ad";
            var result = two.Merge(one);
        }
    }
}

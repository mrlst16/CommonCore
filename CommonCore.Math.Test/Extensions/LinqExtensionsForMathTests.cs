using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using CommonCore.Math.Extensions;

namespace CommonCore.Math.Test.Extensions
{
    public class LinqExtensionsForMathTests
    {
        [Fact]
        public async Task Product_2Times3_Expect6()
        {
            IEnumerable<double> list = new List<double>() { 2, 3 };
            Assert.Equal(6, list.Product());
        }

        [Fact]
        public async Task Product_2Times3Times5_Expect30()
        {
            IEnumerable<double> list = new List<double>() { 2, 3, 5 };
            Assert.Equal(30, list.Product());
        }

        [Fact]
        public async Task Quotient_4DividedBy2_Enpect2()
        {
            IEnumerable<double> list = new List<double>() { 4, 2 };
            Assert.Equal(2, list.Quotient());
        }

        [Fact]
        public async Task Quotient_4DividedBy2By2_Enpect1()
        {
            IEnumerable<double> list = new List<double>() { 4, 2, 2 };
            Assert.Equal(1, list.Quotient());
        }

        [Fact]
        public async Task SumNumbersFromInts_422_Expect8Point8()
        {
            IEnumerable<Number> list = new List<Number>() { 4, 2, 2, .8 };
            double result = list.Sum();
            Assert.Equal(8.8, result);
        }


    }
}

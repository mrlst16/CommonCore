using CommonCore2.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommonCore.Tests.Mathematics
{
    public class HaversineCalculatorTests
    {
        [Fact]
        public void DegreesRadians_Reciprocity()
        {
            HaversineCalculator calculator = new HaversineCalculator();

            double radians = calculator.ToRadians(20);
            double degrees = calculator.ToDegrees(radians);

            Assert.Equal(20, degrees);
        }

        [Fact]
        public void HaversineArcHaversine_At0_Reciprocity()
        {
            HaversineCalculator calculator = new HaversineCalculator();

            double radians = .78;
            double haversine = calculator.Haversine(radians);
            double actual = calculator.ArcHaversine(haversine);

            Assert.Equal(radians, actual);
        }

        [Fact]
        public void HaversineArcHaversine_AtPoint78_Reciprocity()
        {
            HaversineCalculator calculator = new HaversineCalculator();

            double radians = .78;
            double haversine = calculator.Haversine(radians);
            double actual = calculator.ArcHaversine(haversine);

            Assert.Equal(radians, actual);
        }

        [Fact]
        public void HaversineArcHaversine_At1_Reciprocity()
        {
            HaversineCalculator calculator = new HaversineCalculator();

            double radians = 1;
            double haversine = calculator.Haversine(radians);
            double actual = calculator.ArcHaversine(haversine);

            Assert.Equal(radians, actual);
        }

        [Fact]
        public void Distance_40s_ShouldBe0()
        {
            double lat1 = 40;
            double lat2 = 40;
            double lon1 = 40;
            double lon2 = 40;

            HaversineCalculator calculator = new HaversineCalculator();
            var result = calculator.Distance(lat1, lat2, lon1, lon2);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Distance_4040To6060_ShouldBe2621()
        {
            double lat1 = 40;
            double lat2 = 60;
            double lon1 = 40;
            double lon2 = 60;

            HaversineCalculator calculator = new HaversineCalculator();
            var result = calculator.DistanceKm(lat1, lat2, lon1, lon2);
            var actual = Math.Round(result, 0);
            Assert.Equal(2621, actual);
        }

        [Fact]
        public void Distance_Neg40sToPos60s_ShouldBe2621()
        {
            double lat1 = -40;
            double lat2 = 60;
            double lon1 = -40;
            double lon2 = 60;

            HaversineCalculator calculator = new HaversineCalculator();
            var result = calculator.DistanceKm(lat1, lat2, lon1, lon2);
            var actual = Math.Round(result, 0);
            Assert.Equal(14294, actual);
        }

        [Fact]
        public void Longitude2Km_4040To6060_ShouldBe60()
        {
            double lat1 = 40;
            double lat2 = 60;
            double lon1 = 40;
            double lon2 = 60;

            HaversineCalculator calculator = new HaversineCalculator();
            var distance = calculator.DistanceKm(lat1, lat2, lon1, lon2);

            var result = calculator.Longitude2Km(distance, lat1, lat2, lon1);
            var actual = Math.Round(result, 0);
            Assert.Equal(lon2, actual);
        }

    }
}

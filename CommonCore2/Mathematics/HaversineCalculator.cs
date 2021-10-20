using System;

namespace CommonCore2.Mathematics
{
    public class HaversineCalculator
    {
        //hav(d/r) = hav(lat2-lat1) + cos(lat1)cos(lat2)hav(lon2-1on1)
        //To solve for d
        //h = hav(d/r)
        //d = r * archav(h) = 2r * arcsin(sqrt(h))
        //versine(x) = 1 - cos(x)
        //haversine(x) = versine(x) / 2

        public double AdjustBetween0And1(double x)
        {
            while (x < 0)
                x++;
            while (x > 1)
                x--;

            return x;
        }

        public double Haversine(double x)
            => Math.Pow(Math.Sin(x / 2), 2);

        public double ArcHaversine(double haversine) => Math.Asin(Math.Sqrt(haversine)) * 2;

        public double ToRadians(double x) => x * (Math.PI / 180);
        public double ToDegrees(double x) => x / (Math.PI / 180);

        public double Distance(double lat1, double lat2, double lon1, double lon2)
        {
            var tLat1 = ToRadians(lat1);
            var tLat2 = ToRadians(lat2);

            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double h = Haversine(dLat) + (Math.Cos(tLat1) * Math.Cos(tLat2) * Haversine(dLon));

            var result = ArcHaversine(h);
            return result;
        }

        public double DistanceKm(double lat1, double lat2, double lon1, double lon2)
            => 6371 * Distance(lat1, lat2, lon1, lon2);

        public double DistanceMiles(double lat1, double lat2, double lon1, double lon2)
            => 3958.756 * Distance(lat1, lat2, lon1, lon2);


        public double Longitude2(double distance, double lat1, double lat2, double lon1)
        {
            var h = Haversine(distance);
            var tLat1 = ToRadians(lat1);
            var tLat2 = ToRadians(lat2);
            var dLat = ToRadians(lat2 - lat1);

            var b = (h - Haversine(dLat)) / (Math.Cos(tLat1) * Math.Cos(tLat2));

            var dLon = ArcHaversine(b);
            var dLonDeg = ToDegrees(dLon);
            var result = dLonDeg + lon1;
            return result;
        }

        public double Longitude2Km(double distance, double lat1, double lat2, double lon1)
            => Longitude2(distance / 6371, lat1, lat2, lon1);

        public double Longitude2Miles(double distance, double lat1, double lat2, double lon1)
            => Longitude2(distance / 3958.756, lat1, lat2, lon1);
    }
}

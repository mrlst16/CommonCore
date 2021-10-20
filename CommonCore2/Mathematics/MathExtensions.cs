using System;

namespace CommonCore2.Mathematics
{
    public static class MathExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}

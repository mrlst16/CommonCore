using System.Linq;

namespace CommonCore.Extensions
{
    public static class ByteExtensions
    {
        public static bool BytesEqual(this byte[] one, byte[] two)
        {
            if (one == null && two == null) return true;

            if (one == null ^ two == null
                || one.Length != two.Length) return false;

            return !one
                .Where((x, i) => x != two[i])
                .Any();
        }
    }
}

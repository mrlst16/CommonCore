using System.Collections.Generic;

namespace CommonCore2.Extensions
{
    public static class EFExtensions
    {
        public static string ToSqlParamsString(this IDictionary<string, string> dict)
        {
            string result = string.Empty;
            foreach (var kvp in dict)
            {
                result += $"@{kvp.Key}='{kvp.Value}',";
            }
            return result.Trim(',', ' ');
        }

    }
}

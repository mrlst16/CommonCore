using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonCore.Standard.Extensions
{
    public static class StringFileExtensions
    {

        public static string PathFromDeepestFolder(this string path, string folder)
        {
            var index = path.IndexOfToDeepestFolder(folder, out List<string> parts);

            var start = index;
            parts = parts.RangeBetweenInclusive(start, parts.Count-1).ToList();
            return parts.Aggregate((x, y) => $"{x}{Path.DirectorySeparatorChar}{y}");
        }

        public static string PathToDeepestFolder(this string path, string folder)
        {
            var index = path.IndexOfToDeepestFolder(folder, out List<string> parts);

            parts = parts.RangeBetweenInclusive(0, index).ToList();
            return parts.Aggregate((x, y) => $"{x}{Path.DirectorySeparatorChar}{y}");
        }

        public static int IndexOfToDeepestFolder(this string path, string folder, out List<string> parts)
        {
            parts = path.Split(Path.DirectorySeparatorChar).ToList();
            parts.Reverse();

            var indexOf = parts.IndexOf(folder);
            if (indexOf < 0) return -1;

            var result = parts.Count - indexOf - 1;
            parts.Reverse();

            return result;
        }

        public static int IndexOfToShallowestFolder(this string path, string folder, out List<string> parts)
        {
            parts = path.Split(Path.DirectorySeparatorChar).ToList();
            return parts.IndexOf(folder);
        }

        public static string PathBetweenFoldersToDeepestOccurrances(this string path, string startFolder, string endFolder)
        {
            var endIndex = path.IndexOfToDeepestFolder(endFolder, out List<string> parts);
            var startIndex = path.IndexOfToDeepestFolder(startFolder, out parts);
            if (endIndex < startIndex) throw new Exception("Start folder must come before end folder");

            var resultParts = parts.RangeBetweenInclusive(startIndex, endIndex);
            return resultParts.Aggregate((x, y) => $"{x}{Path.DirectorySeparatorChar}{y}");
        }
    }
}

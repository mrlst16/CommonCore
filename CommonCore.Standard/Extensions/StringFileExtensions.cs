using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonCore.Standard.Extensions
{
    public static class StringFileExtensions
    {
        public static string PathFromDeepestFolder(this string path, string folder)
        {
            var index = path.IndexOfToDeepestFolder(folder, out List<string> parts);

            var start = index;
            parts = parts.RangeBetweenInclusive(start, parts.Count - 1).ToList();
            return Path.Combine(parts.ToArray());
        }

        public static string PathToDeepestFolder(this string path, string folder)
        {
            var index = path.IndexOfToDeepestFolder(folder, out List<string> parts);

            parts = parts.RangeBetweenInclusive(0, index).ToList();
            return Path.Combine(parts.ToArray());
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

        //public static int IndexOfToShallowestFolder(this string path, string folder, out List<string> parts)
        //{
        //    parts = path.Split(Path.DirectorySeparatorChar).ToList();
        //    return parts.IndexOf(folder);
        //}

        public static string PathBetweenFoldersToDeepestOccurrances(this string path, string startFolder, string endFolder)
        {
            var endIndex = path.IndexOfToDeepestFolder(endFolder, out List<string> parts);
            var startIndex = path.IndexOfToDeepestFolder(startFolder, out parts);
            if (endIndex < startIndex) throw new Exception("Start folder must come before end folder");

            var resultParts = parts.RangeBetweenInclusive(startIndex, endIndex);
            return Path.Combine(resultParts.ToArray());
        }

        //public static string PathToShallowestFolder(this string path, string folder)
        //{
        //    var index = path.IndexOfToShallowestFolder(folder, out List<string> parts);
        //    parts = parts.RangeBetweenInclusive(0, index).ToList();
        //    return Path.Combine(parts.ToArray());
        //}

        public static string ParentFolderPath(this string path)
        {
            string[] parts = path.Split(Path.DirectorySeparatorChar);
            if (parts.Length < 2) return null;

            var resultParts = parts.RangeBetweenInclusive(0, parts.Length - 2);
            return Path.Combine(resultParts.ToArray());
        }

        //public static string ParentFolderName(this string path)
        //{
        //    IEnumerable<string> parts = path.Split(Path.DirectorySeparatorChar);
        //    if (parts.Count() < 2) return null;

        //    parts = parts.Reverse();
        //    return parts.ElementAt(1);
        //}

        //public static string Filename(this string path)
        //{
        //    IEnumerable<string> parts = path.Split(Path.DirectorySeparatorChar);
        //    var fileName = parts.LastOrDefault();
        //    if (string.IsNullOrWhiteSpace(fileName)) return null;

        //    var fileParts = fileName.Split('.');
        //    if (fileParts.Length < 2) return null;

        //    return fileParts.FirstOrDefault();
        //}

        //public static string FolderName(this string path)
        //{
        //    if (string.IsNullOrWhiteSpace(path)) return null;

        //    IEnumerable<string> parts = path.Split(Path.DirectorySeparatorChar);
        //    if (parts.Count() < 1) return null;
        //    var name = parts.LastOrDefault();
        //    var nameParts = name.Split('.');

        //    return nameParts.ElementAt(0);
        //}
    }
}

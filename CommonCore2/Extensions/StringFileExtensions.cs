using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonCore.Standard.Extensions
{
    public static class StringFileExtensions
    {
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

        public static string ParentFolderName(this string path)
        {
            IEnumerable<string> parts = path.Split(Path.DirectorySeparatorChar);
            if (parts.Count() < 2) return null;

            parts = parts.Reverse();
            return parts.ElementAt(1);
        }

        public static string Filename(this string path)
        {
            IEnumerable<string> parts = path.Split(Path.DirectorySeparatorChar);
            var fileName = parts.LastOrDefault();
            if (string.IsNullOrWhiteSpace(fileName)) return null;

            var fileParts = fileName.Split('.');
            if (fileParts.Length < 2) return null;

            return fileParts.FirstOrDefault();
        }

        public static string FolderName(this string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;

            IEnumerable<string> parts = path.Split(Path.DirectorySeparatorChar);
            if (parts.Count() < 1) return null;
            var name = parts.LastOrDefault();
            var nameParts = name.Split('.');

            return nameParts.ElementAt(0);
        }
    }
}

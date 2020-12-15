using CommonCore2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        const string NAMESPACEPATTERN = "namespace\\s+\\S+\\s+\\{";
        const string NEXTWORDPATTERN = "^\\s+\\S+";

        static string GetNewNamespace(string assemblyFolder, string path)
        {
            var pathParts = path.Split(Path.DirectorySeparatorChar).ToList();
            pathParts.Reverse();
            var to = pathParts.IndexOf(assemblyFolder);
            pathParts = pathParts.GetRange(0, to);
            pathParts.Reverse();
            return $"{assemblyFolder}.{pathParts.Aggregate((x, y) => $"{x}.{y}")}";
        }

        static void ChangeNamespace(string assemblyFolder, string path)
        {
            var text = File.ReadAllText(path);
            var t = "namespace".IndexOf("namespace", 0);
            int nsIndex = 0;
            while ((nsIndex = text.IndexOf("namespace", nsIndex)) > 0)
            {
                Regex nextWord = new Regex("^\\s+\\S+");
                var match = nextWord.Match(text, nsIndex);
                nsIndex++;
            }

        }

        static string ChangeNamespaceFromText(string text, string newNamspace)
        {
            var result = text;
            Regex namespaceRegex = new Regex(NAMESPACEPATTERN);

            Match match = null;
            int startNext = 0;
            var replacementString = " namespace " + newNamspace + System.Environment.NewLine + "{";

            while ((match = namespaceRegex.Match(result, startNext)).Success)
            {
                result = namespaceRegex.Replace(
                    result,
                    replacementString,
                    match.Length,
                    match.Index
                );

                startNext = match.Index + match.Length - (match.Length - replacementString.Length);
            }

            return result;
        }

        static async Task Main(string[] args)
        {
            var directory = @"C:\Users\mattl\source\repos\CommonCore\Lab\TestObjects";
            var files = Directory.GetFiles(directory)?.Where(x => Path.GetExtension(x) == ".cs");
            var assmeblyFolder = "CommonCore";

            var ns = GetNewNamespace(assmeblyFolder, directory);
            Regex nextWord = new Regex("^\\s+\\S+");
            string threeSpacesInFront = "   Lab.Goodies ";
            var results = nextWord.Match(threeSpacesInFront);
            var testText = "namespace Lab.Goodies {class F{}} namespace Lab.Goodies.Sweets {}";


        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonCore.Standard
{
    public static class CommonRegex
    {
        public const string NAMESPACE_PATTERN = "namespace\\s+\\S+\\s+\\{";
        public const string NEXTWORD_PATTERN = "^\\s+\\S+";

        public static Regex NamespaceRegex => new Regex(NAMESPACE_PATTERN);
    }
}

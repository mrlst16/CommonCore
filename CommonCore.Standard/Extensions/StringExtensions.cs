using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonCore.Standard.Extensions
{
    public static class StringExtensions
    {
        //public static int IndexOfClosingCharacter(this string text, char open = '{', char closed = '}', int startAt = 0)
        //{
        //    int charsOpen = 0;
        //    int charsClosed = 0;

        //    for (int i = startAt; i < text.Length; i++)
        //    {
        //        char c = text[i];
        //        if (c == open)
        //        {
        //            charsOpen++;
        //        }
        //        else if (c == closed)
        //        {
        //            charsClosed++;
        //        }

        //        if (charsOpen == charsClosed && charsOpen > 0) return i;
        //    }
        //    return -1;
        //}

        //public static bool Closes(this string text, char open = '{', char closed = '}', int startAt = 0)
        //{
        //    int charsOpen = 0;
        //    int charsClosed = 0;

        //    for (int i = startAt; i < text.Length; i++)
        //    {
        //        char c = text[i];
        //        if (c == open)
        //        {
        //            charsOpen++;
        //        }
        //        else if (c == closed)
        //        {
        //            charsClosed++;
        //        }

        //    }
        //    return charsOpen == charsClosed;
        //}

        //public static int MatchCount(this string str, string regex)
        //    => Regex.Matches(str, regex)?.Count ?? 0;

    }
}

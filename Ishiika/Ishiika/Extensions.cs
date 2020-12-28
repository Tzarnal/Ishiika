using System;
using System.Collections.Generic;
using System.Text;

namespace Ishiika
{
    internal static class Extensions
    {
        public static int Count(this string str, string comp)
        {
            int starLength = str.Length;
            var modified = str.Replace(comp, "");
            int finalLength = modified.Length;

            return (starLength - finalLength) / comp.Length;
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static IEnumerable<string> SplitBySize(this string text, int chunkSize)
        {
            for (int i = 0; i < text.Length; i += chunkSize)
                yield return text.Substring(i, chunkSize);
        }

        public static string Reverse(this string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
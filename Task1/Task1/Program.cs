using System;

namespace Task1
{
    class StringUtils
    {
        /// <summary> <p>Overlays part of a String with another String.</p>
        /// 
        /// <p>A <code>null</code> string input returns <code>null</code>.
        /// A negative index is treated as zero.
        /// An index greater than the string length is treated as the string length.
        /// The start index is always the smaller of the two indices.</p>
        ///     
        /// <pre>
        /// StringUtils.Overlay(null, *, *, *)            = null
        /// StringUtils.Overlay("", "abc", 0, 0)          = "abc"
        /// StringUtils.Overlay("abcdef", null, 2, 4)     = "abef"
        /// StringUtils.Overlay("abcdef", "", 2, 4)       = "abef"
        /// StringUtils.Overlay("abcdef", "", 4, 2)       = "abef"
        /// StringUtils.Overlay("abcdef", "zzzz", 2, 4)   = "abzzzzef"
        /// StringUtils.Overlay("abcdef", "zzzz", 4, 2)   = "abzzzzef"
        /// StringUtils.Overlay("abcdef", "zzzz", -1, 4)  = "zzzzef"
        /// StringUtils.Overlay("abcdef", "zzzz", 2, 8)   = "abzzzz"
        /// StringUtils.Overlay("abcdef", "zzzz", -2, -3) = "zzzzabcdef"
        /// StringUtils.Overlay("abcdef", "zzzz", 8, 10)  = "abcdefzzzz"
        /// </pre>
        /// 
        /// </summary>
        /// <param name="str"> the String to do overlaying in, may be null
        /// </param>
        /// <param name="overlay"> the String to Overlay, may be null
        /// </param>
        /// <param name="start"> the position to start overlaying at
        /// </param>
        /// <param name="end"> the position to stop overlaying before
        /// </param>
        /// <returns> overlayed String, <code>null</code> if null String input
        /// </returns>
        /// <since> 2.0
        /// </since>

        public static System.String Overlay(System.String str, System.String overlay, int start, int end)
        {
            if (str == null) return null;
            int maxIndex = Math.Max(start, end);
            int minIndex = Math.Min(start, end);
            string resultString = "";
            if (minIndex < 0) minIndex = 0;
            if (minIndex > str.Length) minIndex = str.Length;
            if (maxIndex < 0) maxIndex = 0;
            if (maxIndex > str.Length) maxIndex = str.Length;

            if (str.Length == 0) { return resultString + overlay; }
            for (int i = 0; i < str.Length; i++)
            {
                if (i < minIndex) resultString += str[i];
                if (i == minIndex) resultString += overlay;
                if (i >= maxIndex) resultString += str[i];
            }
            if (str.Length == minIndex) resultString += overlay;
            return resultString;
        }
        static void Main(string[] args)
        {
            if (StringUtils.Overlay(null, null, 1, 2) == null) Console.WriteLine("0 Correct"); else Console.WriteLine("0 Failed");
            if (StringUtils.Overlay("", "abc", 0, 0) == "abc") Console.WriteLine("1 Correct"); else Console.WriteLine("1 Failed {0}", StringUtils.Overlay("", "abc", 0, 0));
            if (StringUtils.Overlay("abcdef", null, 2, 4) == "abef") Console.WriteLine("2 Correct"); else Console.WriteLine("2 Failed");
            if (StringUtils.Overlay("abcdef", "", 2, 4) == "abef") Console.WriteLine("3 Correct"); else Console.WriteLine("3 Failed");
            if (StringUtils.Overlay("abcdef", "", 4, 2) == "abef") Console.WriteLine("4 Correct"); else Console.WriteLine("4 Failed");
            if (StringUtils.Overlay("abcdef", "zzzz", 2, 4) == "abzzzzef") Console.WriteLine("5 Correct"); else Console.WriteLine("5 Failed");
            if (StringUtils.Overlay("abcdef", "zzzz", 4, 2) == "abzzzzef") Console.WriteLine("6 Correct"); else Console.WriteLine("6 Failed");
            if (StringUtils.Overlay("abcdef", "zzzz", -1, 4) == "zzzzef") Console.WriteLine("7 Correct"); else Console.WriteLine("7 Failed");
            if (StringUtils.Overlay("abcdef", "zzzz", 2, 8) == "abzzzz") Console.WriteLine("8 Correct"); else Console.WriteLine("8 Failed");
            if (StringUtils.Overlay("abcdef", "zzzz", -2, -3) == "zzzzabcdef") Console.WriteLine("9 Correct"); else Console.WriteLine("9 Failed");
            if (StringUtils.Overlay("abcdef", "zzzz", 8, 10) == "abcdefzzzz") Console.WriteLine("10 Correct"); else Console.WriteLine("10 Failed");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core31
{
    public static class StringExtension
    {
        public static string GetSubString(this string input, string start, string end, bool includeBeginning = false, bool includeEnd = false)
        {
            var startInd = input.IndexOf(start);
            var len = input.Length;
            
            if (startInd == -1)
                return null;

            var sub = includeBeginning ? input.Substring(startInd, len - startInd) : input.Substring(startInd + start.Length, len - (startInd + start.Length));

            var endInd = sub.IndexOf(end);

            if (endInd == -1)
                return null;

            return includeEnd ? sub.Substring(0, (endInd + end.Length)) : sub.Substring(0, endInd);
        }
    }
}

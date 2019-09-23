using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Extensions
{
    public static class StringExtensions
    {
        public static int CountOccurences(this string str, char chr, int startIndex, int count)
        {
            int occurences = 0;
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (str[i] == chr)
                {
                    occurences++;
                }
            }
            return occurences;
        }
    }
}

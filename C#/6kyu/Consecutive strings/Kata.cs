using System.Text;
using System;

namespace Kata
{
    public class LongestConsecutives
    {
        public static String LongestConsec(string[] strarr, int k)
        {
            StringBuilder maxString = new StringBuilder();

            for (int i = 0; i < strarr.Length - (k - 1); i++)
            {
                StringBuilder currentString = new StringBuilder();

                for (int j = 0; j < k; j++)
                    currentString.Append(strarr[i + j]);

                if (maxString.Length < currentString.Length)
                    maxString = currentString;
            }

            return maxString.ToString();
        }
    }
}
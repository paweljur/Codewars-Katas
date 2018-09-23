using System.Text;
using System.Collections.Generic;

namespace Kata
{
    public class KataClass
    {
        /*
         * input -> output
         * 35142 -> 35214
         * 35 - common part between smaller and next bigger
         * 1 - delimiter
         * 2 - min substitute for delimeter
         * 14 - sorted/minimal different part between smaller and next bigger
         */
        public static long NextBiggerNumber(long n)
        {
            string smaller = n.ToString();
            long nextBigger = -1;
            List<char> differentPart = new List<char> {smaller[smaller.Length - 1]};

            for (int i = smaller.Length - 2; i >= 0; i--)
            {
                if (CheckIfDelimiter(smaller, i))
                {
                    char delimiter = smaller[i];

                    differentPart.Add(delimiter);
                    differentPart.Sort();

                    char minSubstitue = differentPart.Find(c => c > delimiter);
                    differentPart.Remove(minSubstitue);

                    nextBigger = CreateNextBigger(smaller.Substring(0, i), minSubstitue, differentPart);
                    break;
                }

                differentPart.Add(smaller[i]);

            }

            return nextBigger;
        }

        private static bool CheckIfDelimiter(string smaller, int i)
        {
            return smaller[i + 1] > smaller[i];
        }

        private static long CreateNextBigger(string commonPart, char delimiterSubstitute, List<char> differentPart)
        {
            StringBuilder nextBigger = new StringBuilder();
            nextBigger.Append(commonPart);
            nextBigger.Append(delimiterSubstitute);

            foreach (char c in differentPart)
                nextBigger.Append(c);
            return long.Parse(nextBigger.ToString());
        }
    }
}
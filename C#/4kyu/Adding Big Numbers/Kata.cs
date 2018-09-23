using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class KataClass
    {
        // well, i guess it would be too easy
        // public static string Add(string a, string b)
        // {
        //     BigInteger.TryParse(a, out BigInteger parsedA);
        //     BigInteger.TryParse(b, out BigInteger parsedB);
        //     return (parsedA + parsedB).ToString();
        // }
        public static string Add(string a, string b)
        {
            return a.Length < b.Length ? AddStrings(b, a) : AddStrings(a, b);
        }

        public static string AddStrings(string longerString, string shorterString)
        {
            List<int> result = new List<int>();
            bool transfer = false;
            int[] longerNumber = longerString.Reverse().Select(c => int.Parse(c.ToString())).ToArray();
            int[] shorterNumber = shorterString.Reverse().Select(c => int.Parse(c.ToString())).ToArray();

            for (int i = 0; i < shorterNumber.Length; i++)
            {
                int tmp = transfer ? shorterNumber[i] + longerNumber[i] + 1 : shorterNumber[i] + longerNumber[i];
                transfer = false;
                result.Add(tmp < 10 ? tmp : tmp - 10);
                transfer = tmp >= 10;
            }

            int index = shorterNumber.Length;

            while (transfer && index < longerNumber.Length)
            {
                int tmp = transfer ? longerNumber[index] + 1 : longerNumber[index];
                transfer = false;
                result.Add(tmp < 10 ? tmp : tmp - 10);
                transfer = tmp >= 10;
                index++;
            }

            if (!transfer && index < longerNumber.Length)
            {
                result.AddRange(longerNumber.Skip(index));
            }
            else if (transfer)
            {
                result.Add(1);
            }

            result.Reverse();
            return string.Concat(result);
        }
    }
}
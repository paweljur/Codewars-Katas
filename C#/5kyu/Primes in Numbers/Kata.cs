using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class KataClass
    {

        public static string factors(int lst)
        {
            Dictionary<int, int> allPrimeNumbers = new Dictionary<int, int>();

            if (lst == 1)
            {
                AddToDictionary(allPrimeNumbers, 1);
            }

            for (int i = 2; i < lst; i++)
            {
                int remainder = lst % i;
                if (remainder == 0)
                {
                    AddToDictionary(allPrimeNumbers, i);
                    lst /= i;
                    i = 1;
                }
            }

            if (lst != 1)
            {
                AddToDictionary(allPrimeNumbers, lst);
            }

            return CreateString(allPrimeNumbers);
        }

        private static string CreateString(Dictionary<int, int> allPrimeNumbers)
        {
            StringBuilder sr = new StringBuilder();
            foreach (var primeNumber in allPrimeNumbers)
            {
                if (primeNumber.Value == 1)
                {
                    sr.Append($"({primeNumber.Key})");
                }
                else
                {
                    sr.Append($"({primeNumber.Key}**{primeNumber.Value})");
                }
            }

            return sr.ToString();
        }

        private static void AddToDictionary(Dictionary<int, int> allPrimeNumbers, int remainder)
        {
            if (allPrimeNumbers.ContainsKey(remainder))
            {
                allPrimeNumbers[remainder]++;
            }
            else
            {
                allPrimeNumbers.Add(remainder, 1);
            }
        }
    }
}
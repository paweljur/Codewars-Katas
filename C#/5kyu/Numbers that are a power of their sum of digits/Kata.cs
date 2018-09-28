using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class PowerSumDig
    {

        public static long PowerSumDigTerm(int n)
        {
            Dictionary<int, List<int>> everyPossiblePowers = FindPowersOfEveryPossibleSum();
            List<long> matches = FindPowersWithSumOfDigitsAsBase(everyPossiblePowers);

            return n <= matches.Count ? matches[n - 1] : 0;
        }

        public static List<long> FindPowersWithSumOfDigitsAsBase(Dictionary<int, List<int>> everyPossiblePowers)
        {
            List<long> result = new List<long>();

            foreach (var v in everyPossiblePowers)
            foreach (int i in v.Value)
            {
                long power = (long)Math.Pow(v.Key, i);
                long sumOfDigits = power.ToString().Select(c => long.Parse(c.ToString())).Sum();
                if (sumOfDigits == v.Key)
                    result.Add(power);
            }

            result.Sort();
            return result;
        }

        public static Dictionary<int, List<int>> FindPowersOfEveryPossibleSum()
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            int maxSum = int.MaxValue.ToString().Length * 9;
            for (int i = 2; i < maxSum; i++)
            for (int j = 2; Math.Pow(i, j) < long.MaxValue; j++)
            {
                if (result.ContainsKey(i))
                    result[i].Add(j);
                else
                    result.Add(i, new List<int>() { j });
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class MaxSumDigits
    {
        private const int MinNumber = 1000;
        private const int NumOfConsecDigits = 4;

        public static long[] MaxSumDig(long nmax, int maxSum)
        {
            List<long> viableNumbers = FindAllViable(nmax, maxSum).ToList();
            long closestToMean = FindClosestToMean(viableNumbers);

            long[] result = {
                viableNumbers.Count,
                closestToMean,
                viableNumbers.Sum()
            };

            return result;
        }

        private static long FindClosestToMean(List<long> viableNumbers)
        {
            long sum = viableNumbers.Sum();
            double mean = sum / viableNumbers.Count;
            (long value, double fromMean) result = (viableNumbers.First(), Math.Abs(viableNumbers.First() - mean));

            foreach (long number in viableNumbers.Skip(1))
            {
                double fromMean = Math.Abs(number - mean);

                if (fromMean < result.fromMean)
                    result = (number, fromMean);
                else if (fromMean == result.fromMean && number > result.value)
                    result = (number, fromMean);
            }

            return result.value;
        }

        private static IEnumerable<long> FindAllViable(long nmax, int maxSum)
        {
            for (long i = MinNumber; i <= nmax; i++)
                if (AnyDigitSumInRange(i, maxSum))
                    yield return i;
        }

        public static bool AnyDigitSumInRange(long number, int maxSum)
        {
            var digits = number.ToString().Select(c => long.Parse(c.ToString())).ToList();
            int numberOfPossibleDigitSets = digits.Count - NumOfConsecDigits + 1;

            for (int j = 0; j < numberOfPossibleDigitSets; j++)
            {
                var digitSet = digits.GetRange(j, NumOfConsecDigits);
                if (digitSet.Sum() <= maxSum)
                    return true;
            }

            return false;
        }
    }
}
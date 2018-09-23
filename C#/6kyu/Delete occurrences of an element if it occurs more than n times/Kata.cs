using System;
using System.Collections.Generic;

namespace Kata
{
    public class KataClass
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            Dictionary<int, int> occurenceCount = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach (var i in arr)
            {
                if (occurenceCount.ContainsKey(i))
                    occurenceCount[i]++;
                else
                    occurenceCount.Add(i, 1);

                if (occurenceCount[i] <= x)
                    result.Add(i);
            }

            return result.ToArray();
        }
    }
}
using System;
using System.Linq;

namespace Kata
{
    public class KataClass
    {

        public static bool Scramble(string available, string expected)
        {
            var availableLetters = available.ToList();
            bool result = true;

            foreach (char c in expected)
            {
                if (!availableLetters.Remove(c))
                    result = false;
            }

            return result;
        }

    }
}
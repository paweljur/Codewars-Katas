using System;
using System.Numerics;

namespace Kata
{
    public class KataClass
    {
        public static BigInteger perimeter(BigInteger n)
        {
            BigInteger result = new BigInteger(4);
            BigInteger last = 1;
            BigInteger secondToLast = 0;

            for (BigInteger i = 0; i < n; i++)
            {
                BigInteger current = last + secondToLast;
                result += current * 4;
                secondToLast = last;
                last = current;
            }

            return result;
        }
    }
}
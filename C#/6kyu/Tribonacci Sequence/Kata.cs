using System;

namespace Kata
{
    public class Xbonacci
    {
        public double[] Tribonacci(double[] signature, int n)
        {
            if (signature.Length != 3)
                return new double[] { 0 };

            double[] arrayacci = new double[n];
            Array.Copy(signature, arrayacci, n > 3 ? 3 : n);

            for (int i = 3; i < n; i++)
                arrayacci[i] = arrayacci[i - 1] + arrayacci[i - 2] + arrayacci[i - 3];

            return n != 0 ? arrayacci : new double[] { 0 };
        }
    }
}
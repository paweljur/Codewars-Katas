using System;
using System.Text;

namespace Kata
{
    public static class KataClass
    {
        public static string AddBinary(int a, int b)
        {
            //i guess thats not the point of this one
            //return Convert.ToString(a + b, 2);

            int sum = a + b;
            StringBuilder sr = new StringBuilder();

            while (sum != 0)
            {
                sr.Insert(0, sum % 2);
                sum = sum / 2;
            }

            return sr.ToString();
        }
    }
}
namespace Kata
{
    public class ASum
    {
        public static long findNb(long m)
        {
            long counter = 0;
            while (0 < m)
            {
                counter++;
                m -= counter * counter * counter;
            }

            return m == 0 ? counter : -1;
        }
    }
}
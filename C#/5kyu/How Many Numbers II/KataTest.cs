using System;
using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public static class MaxSumDigitsTests
    {

        private static void testing(long nmax, int maxsm, long[] res)
        {
            Assert.AreEqual(Array2String(res), Array2String(MaxSumDigits.MaxSumDig(nmax, maxsm)));
        }
        private static string Array2String(long[] list)
        {
            return "[" + string.Join(", ", list) + "]";
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests MaxSumDig");
            testing(2000, 3, new long[] { 11, 1110, 12555 });
            testing(2000, 4, new long[] { 21, 1120, 23665 });
            testing(2000, 7, new long[] { 85, 1200, 99986 });
            testing(3000, 7, new long[] { 141, 1600, 220756 });
        }
    }
}
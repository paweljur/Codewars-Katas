using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public static class PowerSumDigTests
    {
        private static void testing(long actual, long expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void testBasic()
        {
            testing(PowerSumDig.PowerSumDigTerm(1), 81);
            testing(PowerSumDig.PowerSumDigTerm(2), 512);
            testing(PowerSumDig.PowerSumDigTerm(3), 2401);
            testing(PowerSumDig.PowerSumDigTerm(4), 4913);
            testing(PowerSumDig.PowerSumDigTerm(1), 81);
        }
        [Test]
        public static void testHigh()
        {
            testing(PowerSumDig.PowerSumDigTerm(15), 60466176);
            testing(PowerSumDig.PowerSumDigTerm(21), 27512614111);
            testing(PowerSumDig.PowerSumDigTerm(28), 20047612231936);
            testing(PowerSumDig.PowerSumDigTerm(31), 3904305912313344);
        }
    }
}
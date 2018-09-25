using System;
using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public class KataTests
    {
        private static void testing(bool actual, bool expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(21, KataClass.NextBiggerNumber(12));
            Assert.AreEqual(531, KataClass.NextBiggerNumber(513));
            Assert.AreEqual(2071, KataClass.NextBiggerNumber(2017));
            Assert.AreEqual(441, KataClass.NextBiggerNumber(414));
            Assert.AreEqual(414, KataClass.NextBiggerNumber(144));
            Assert.AreEqual(1754102208, KataClass.NextBiggerNumber(1754102082));
        }
    }
}
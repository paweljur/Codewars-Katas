using System;
using NUnit.Framework;
using System.Numerics;
using Kata;

namespace Tests
{
    [TestFixture]
    public class SumFctTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(new BigInteger(80), KataClass.perimeter(new BigInteger(5)));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(new BigInteger(216), KataClass.perimeter(new BigInteger(7)));
        }
    }
}
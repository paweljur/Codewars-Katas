using System;
using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public class HumanReadableTimeTest
    {
        [Test]
        public void HumanReadableTest()
        {
            Assert.AreEqual("00:00:00", KataClass.GetReadableTime(0));
            Assert.AreEqual("00:00:05", KataClass.GetReadableTime(5));
            Assert.AreEqual("00:01:00", KataClass.GetReadableTime(60));
            Assert.AreEqual("23:59:59", KataClass.GetReadableTime(86399));
            Assert.AreEqual("99:59:59", KataClass.GetReadableTime(359999));
        }
    }
}
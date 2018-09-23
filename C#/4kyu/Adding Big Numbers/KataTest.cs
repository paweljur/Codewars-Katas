using System;
using NUnit.Framework;

namespace Kata
{
    [TestFixture]
    public class KataTest
    {
        [Test]
        public void ASimpleKataTest()
        {
            Assert.AreEqual("110", KataClass.Add("91", "19"));
            Assert.AreEqual("1111111111", KataClass.Add("123456789", "987654322"));
            Assert.AreEqual("16152487201288156", KataClass.Add("7425963542589632", "8726523658698524"));
        }
    }
}
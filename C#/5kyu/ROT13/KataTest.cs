using NUnit.Framework;
using System;
using System.Linq;

namespace Kata
{
    [TestFixture]
    public class SystemTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("ROT13 example.", KataClass.Rot13("EBG13 rknzcyr."));
        }
    }
}
using System;
using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public class AddBinaryTest
    {
        [Test]
        public void TestExample()
        {
            Assert.AreEqual("11", KataClass.AddBinary(1, 2), "Should return \"11\" for 1 + 2");
        }
    }
}
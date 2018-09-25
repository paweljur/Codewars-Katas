using NUnit.Framework;
using System;
using Kata;

namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual('e', KataClass.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', KataClass.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }
    }
}
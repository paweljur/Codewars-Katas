using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void TestDictionaryCreation()
        {
            //given
            var result = KataClass.CreateHamsterEncryptionDictionary("hamster");
            Assert.AreEqual("a1", result['a']);
            Assert.AreEqual("t7", result['z']);
            Assert.AreEqual("s1", result['s']);
            Assert.AreEqual("e2", result['f']);
        }

        [Test]
        public void EasyHamsters()
        {
            Assert.AreEqual("h1a1m1s1t1e1r1", KataClass.HamsterMe("hamster", "hamster"));
            Assert.AreEqual("h1e1h5m4m1e1", KataClass.HamsterMe("hamster", "helpme"));
            Assert.AreEqual("h1t8m1s1t1e1r1", KataClass.HamsterMe("hmster", "hamster"));
            Assert.AreEqual("h1a1m1s1t1e1r1", KataClass.HamsterMe("hhhhammmstteree", "hamster"));
            Assert.AreEqual("a1a2a3a4e1e2e3h1h2h3h4h5m1m2m3m4m5r1s1t1t2t3t4t5t6t7", KataClass.HamsterMe("hamster", "abcdefghijklmnopqrstuvwxyz"));
            Assert.AreEqual("f22f23f24f25f26f1f2f3f4f5f6f7f8f9f10f11f12f13f14f15f16f17f18f19f20f21", KataClass.HamsterMe("f", "abcdefghijklmnopqrstuvwxyz"));
        }
    }
}
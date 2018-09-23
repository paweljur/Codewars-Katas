using System;
using NUnit.Framework;

namespace Kata
{
    [TestFixture]
    public class KataTests
    {

        [Test]
        public void Test1()
        {

            int lst = 7775460;
            Assert.AreEqual("(2**2)(3**3)(5)(7)(11**2)(17)", KataClass.factors(lst));
        }
    }
}
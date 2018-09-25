using System;
using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public static class ScrambliesTests
    {

        private static void testing(bool actual, bool expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            testing(KataClass.Scramble("rkqodlw", "world"), true);
            testing(KataClass.Scramble("cedewaraaossoqqyt", "codewars"), true);
            testing(KataClass.Scramble("katas", "steak"), false);
            testing(KataClass.Scramble("scriptjavx", "javascript"), false);
            testing(KataClass.Scramble("scriptingjava", "javascript"), true);
            testing(KataClass.Scramble("scriptsjava", "javascripts"), true);
            testing(KataClass.Scramble("javscripts", "javascript"), false);
            testing(KataClass.Scramble("aabbcamaomsccdd", "commas"), true);
            testing(KataClass.Scramble("commas", "commas"), true);
            testing(KataClass.Scramble("sammoc", "commas"), true);
        }
    }
}
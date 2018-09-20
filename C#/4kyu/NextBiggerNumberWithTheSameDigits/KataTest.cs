using System;
using NUnit.Framework;
using Kata;

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
        Assert.AreEqual(21, Kata.NextBiggerNumber(12));
        Assert.AreEqual(531, Kata.NextBiggerNumber(513));
        Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
        Assert.AreEqual(441, Kata.NextBiggerNumber(414));
        Assert.AreEqual(414, Kata.NextBiggerNumber(144));
        Assert.AreEqual(1754102208, Kata.NextBiggerNumber(1754102082));
    }
}
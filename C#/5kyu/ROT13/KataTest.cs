using NUnit.Framework;
using System;
using System.Linq;
using Kata;

[TestFixture]
public class SystemTests
{
    [Test]
    public void Test1()
    {
        Assert.AreEqual("ROT13 example.", Kata.Rot13("EBG13 rknzcyr."));
    }
}
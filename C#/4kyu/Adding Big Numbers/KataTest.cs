using System;
using NUnit.Framework;
using Kata;

[TestFixture]
public class KataTest
{
    [Test]
    public void ASimpleKataTest()
    {
        Assert.AreEqual("110", Kata.Add("91", "19"));
        Assert.AreEqual("1111111111", Kata.Add("123456789", "987654322"));
        Assert.AreEqual("16152487201288156", Kata.Add("7425963542589632", "8726523658698524"));
    }
}
using System;
using NUnit.Framework;
using Kata;

[TestFixture]
public class HumanReadableTimeTest
{
    [Test]
    public void HumanReadableTest()
    {
        Assert.AreEqual("00:00:00", Kata.GetReadableTime(0));
        Assert.AreEqual("00:00:05", Kata.GetReadableTime(5));
        Assert.AreEqual("00:01:00", Kata.GetReadableTime(60));
        Assert.AreEqual("23:59:59", Kata.GetReadableTime(86399));
        Assert.AreEqual("99:59:59", Kata.GetReadableTime(359999));
    }
}
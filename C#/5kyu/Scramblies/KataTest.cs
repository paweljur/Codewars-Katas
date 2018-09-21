using System;
using NUnit.Framework;
using Kata;

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
        testing(Kata.Scramble("rkqodlw","world"), true);
        testing(Kata.Scramble("cedewaraaossoqqyt","codewars"),true);
        testing(Kata.Scramble("katas","steak"),false);
        testing(Kata.Scramble("scriptjavx","javascript"),false);
        testing(Kata.Scramble("scriptingjava","javascript"),true);
        testing(Kata.Scramble("scriptsjava","javascripts"),true);
        testing(Kata.Scramble("javscripts","javascript"),false);
        testing(Kata.Scramble("aabbcamaomsccdd","commas"),true);
        testing(Kata.Scramble("commas","commas"),true);
        testing(Kata.Scramble("sammoc","commas"),true);
    }
}
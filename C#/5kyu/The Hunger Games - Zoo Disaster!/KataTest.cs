using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void EmptyExample()
        {
            string input = "";
            string[] expected = { "" };

            Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
        }
        [Test]
        public void NothingEatenExample()
        {
            string input = "chicken,sheep";
            string[] expected =
            {
                "chicken,sheep",
                "chicken,sheep"
            };

            Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
        }
        [Test]
        public void Example()
        {
            string input = "fox,bug,chicken,grass,sheep";
            string[] expected = {
                "fox,bug,chicken,grass,sheep",
                "chicken eats bug",
                "fox eats chicken",
                "sheep eats grass",
                "fox eats sheep",
                "fox"
            };

            Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
        }
        [Test]
        public void Example1()
        {
            string input = "giraffe,leaves,grass,antelope,cow,panda,giraffe,chicken,grass,cow,giraffe";
            string[] expected = {
                "giraffe,leaves,grass,antelope,cow,panda,giraffe,chicken,grass,cow,giraffe",
                "giraffe eats leaves",
                "antelope eats grass",
                "cow eats grass",
                "giraffe,antelope,cow,panda,giraffe,chicken,cow,giraffe"
            };

            Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
        }
    }
}
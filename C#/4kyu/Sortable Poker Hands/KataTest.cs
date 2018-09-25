using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Kata;

namespace Tests
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void HighCardHandTypesTest()
        {
            //given
            PokerHand highCard = new PokerHand("2S 3D 5S 6C 7C");


            //then
            Assert.AreEqual(PokerHandTypes.HighCard, highCard.Type.Value);
        }

        [Test]
        public void PairHandTypesTest()
        {
            //given
            PokerHand pair = new PokerHand("AS 2S 3S 3C 5C");

            //then
            Assert.AreEqual(PokerHandTypes.Pair, pair.Type.Value);
        }

        [Test]
        public void TwoPairsHandTypesTest()
        {
            //given
            PokerHand twoPairs = new PokerHand("AS AH KC KD 5C");

            //then
            Assert.AreEqual(PokerHandTypes.TwoPair, twoPairs.Type.Value);
        }

        [Test]
        public void ThreeOfAKindHandTypesTest()
        {
            //given
            PokerHand threeOfAKind = new PokerHand("TS TC TH 8C 9C");

            //then
            Assert.AreEqual(PokerHandTypes.ThreeOfAKind, threeOfAKind.Type.Value);

        }

        [Test]
        public void LowStraightHandTypesTest()
        {
            //given
            PokerHand straight = new PokerHand("AS 2C 3H 4C 5C");

            //then
            Assert.AreEqual(PokerHandTypes.LowStraight, straight.Type.Value);

        }

        [Test]
        public void StraightHandTypesTest()
        {
            //given
            PokerHand straight = new PokerHand("AS KC QH JC TC");

            //then
            Assert.AreEqual(PokerHandTypes.Straight, straight.Type.Value);

        }

        [Test]
        public void FlushHandTypesTest()
        {
            //given
            PokerHand flush = new PokerHand("2S TS JS 4S 6S");

            //then
            Assert.AreEqual(PokerHandTypes.Flush, flush.Type.Value);

        }

        [Test]
        public void FullHouseHandTypesTest()
        {
            //given
            PokerHand fullHouse = new PokerHand("TS TC TH 8C 8D");

            //then
            Assert.AreEqual(PokerHandTypes.FullHouse, fullHouse.Type.Value);

        }

        [Test]
        public void LowStraightFlushHandTypesTest()
        {
            //given
            PokerHand straightFlush = new PokerHand("AS 2S 3S 4S 5S");

            //then
            Assert.AreEqual(PokerHandTypes.LowStraightFlush, straightFlush.Type.Value);

        }

        [Test]
        public void StraightFlushHandTypesTest()
        {
            //given
            PokerHand straightFlush = new PokerHand("6S 2S 3S 4S 5S");

            //then
            Assert.AreEqual(PokerHandTypes.StraightFlush, straightFlush.Type.Value);

        }

        [Test]
        public void RoyalFlushHandTypesTest()
        {
            //given
            PokerHand royalFlush = new PokerHand("AS KS QS JS TS");

            //then
            Assert.AreEqual(PokerHandTypes.RoyalFlush, royalFlush.Type.Value);

        }

        [Test]
        public void PokerHandSortTest()
        {
            // Arrange
            var expected = new List<PokerHand> {
                new PokerHand("KS AS TS QS JS"),
                new PokerHand("2H 3H 4H 5H 6H"),
                new PokerHand("AS AD AC AH JD"),
                new PokerHand("JS JD JC JH 3D"),
                new PokerHand("2S AH 2H AS AC"),
                new PokerHand("KC 9C 8C 5C 4C"),
                new PokerHand("KS 9S 8S 5S 3S"),
                new PokerHand("2S 3H 4H 5S 6C"),
                new PokerHand("2D AC 3H 4H 5S"),
                new PokerHand("AH AC 5H 6H AS"),
                new PokerHand("2S 2H 4H 5S 4C"),
                new PokerHand("AH AC 5H 6H 7S"),
                new PokerHand("AH AC 4H 6H 7S"),
                new PokerHand("2S AH 4H 5S KC"),
                new PokerHand("2S 3H 6H 7S 9C")
            };
            var random = new Random((int)DateTime.Now.Ticks);
            var actual = expected.OrderBy(x => random.Next()).ToList();
            // Act
            actual.Sort();
            // Assert
            for (var i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i], "Unexpected sorting order at index {0}", i);
        }
    }
}
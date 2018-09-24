using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kata
{
    public enum ValueType
    {
        Ace,
        King,
        Queen,
        Jack,
        Ten,
        Nine,
        Eight,
        Seven,
        Six,
        Five,
        Four,
        Three,
        Two
    }

    public enum SuitType
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public class Card : IComparable<Card>
    {
        private readonly string _stringRepresentation;
        public ValueType Value { get; }
        public SuitType Suit { get; }

        public Dictionary<char, ValueType> ValueConversionDict = new Dictionary<char, ValueType>()
        {
            {'A', ValueType.Ace},
            {'K', ValueType.King},
            {'Q', ValueType.Queen},
            {'J', ValueType.Jack},
            {'T', ValueType.Ten},
            {'9', ValueType.Nine},
            {'8', ValueType.Eight},
            {'7', ValueType.Seven},
            {'6', ValueType.Six},
            {'5', ValueType.Five},
            {'4', ValueType.Four},
            {'3', ValueType.Three},
            {'2', ValueType.Two}
        };

        public Dictionary<char, SuitType> SuitConversionDict = new Dictionary<char, SuitType>()
        {
            {'S', SuitType.Spades},
            {'H', SuitType.Hearts},
            {'D', SuitType.Diamonds},
            {'C', SuitType.Clubs}
        };

        public Card(char value, char suit)
        {
            _stringRepresentation = $"{value}{suit}";
            Value = ValueConversionDict[value];
            Suit = SuitConversionDict[suit];
        }

        public int CompareTo(Card other)
        {
            int result = Value.CompareTo(other.Value);
            if (result == 0)
                result = Suit.CompareTo(other.Suit);

            return result;
        }

        public override string ToString()
        {
            return _stringRepresentation;
        }
    }





    public enum PokerHandRank
    {
        RoyalFlush,
        StraightFlush,
        LowStraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        LowStraight,
        ThreeOfAKind,
        TwoPair,
        Pair,
        HighCard
    }

    public static class HandRanking
    {
        public static PokerHandRank DetermineType(List<Card> hand)
        {
            Dictionary<int, int> countOfValuesCount = hand.GroupBy(x => x.Value)
                                                          .GroupBy(p => p.Count())
                                                          .ToDictionary(x => x.Key, x => x.Count());
            Dictionary<SuitType, int> suitCount = hand.GroupBy(x => x.Suit)
                                                      .ToDictionary(x => x.Key, x => x.Count());
            List<ValueType> handValues = hand.Select(x => x.Value).ToList();

            //the most specif checks have to be performed first, less specifis not secured for more specific
            if (CheckForRoyalFlush(countOfValuesCount, handValues, suitCount)) return PokerHandRank.RoyalFlush;
            if (CheckForFourOfAKind(countOfValuesCount)) return PokerHandRank.FourOfAKind;
            if (CheckForStraightFlush(countOfValuesCount, handValues, suitCount)) return PokerHandRank.StraightFlush;
            if (CheckForLowStraightFlush(countOfValuesCount, handValues, suitCount)) return PokerHandRank.LowStraightFlush;
            if (CheckForFullHouse(countOfValuesCount)) return PokerHandRank.FullHouse;
            if (CheckForFlush(suitCount)) return PokerHandRank.Flush;
            if (CheckForStraight(countOfValuesCount, handValues)) return PokerHandRank.Straight;
            if (CheckForLowStraight(countOfValuesCount, handValues)) return PokerHandRank.LowStraight;
            if (CheckForThreeOfAKind(countOfValuesCount)) return PokerHandRank.ThreeOfAKind;
            if (CheckForDoublePair(countOfValuesCount)) return PokerHandRank.TwoPair;
            if (CheckForPair(countOfValuesCount)) return PokerHandRank.Pair;
            return PokerHandRank.HighCard;
        }

        private static bool CheckForHighCard(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(1) && countOfValuesCount[1] == 5;
        }

        private static bool CheckForPair(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(2) && !countOfValuesCount.ContainsKey(3) &&
                   countOfValuesCount[2] == 1;
        }

        private static bool CheckForDoublePair(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(2) && countOfValuesCount[2] == 2;
        }

        private static bool CheckForThreeOfAKind(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(3) && !countOfValuesCount.ContainsKey(2);
        }

        private static bool CheckForFourOfAKind(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(4) && countOfValuesCount[4] == 1;
        }

        private static bool CheckForFullHouse(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(3) && countOfValuesCount.ContainsKey(2);
        }

        private static bool CheckForFlush(Dictionary<SuitType, int> suitCount)
        {
            return suitCount.ContainsValue(5);
        }

        private static bool CheckForLowStraight(Dictionary<int, int> countOfValuesCount,
            List<ValueType> values)
        {
            return values.Last() == ValueType.Two &&
                   values.Contains(ValueType.Ace) &&
                   CheckForStraight(countOfValuesCount, values.Skip(1).ToList());
        }

        private static bool CheckForStraight(Dictionary<int, int> countOfValuesCount,
            List<ValueType> values)
        {
            return CheckForHighCard(countOfValuesCount) && values.Last() - values.First() == values.Count - 1;
        }

        private static bool CheckForLowStraightFlush(Dictionary<int, int> countOfValuesCount,
            List<ValueType> values, Dictionary<SuitType, int> suitCount)
        {
            return CheckForFlush(suitCount) && CheckForLowStraight(countOfValuesCount, values);
        }

        private static bool CheckForStraightFlush(Dictionary<int, int> countOfValuesCount,
            List<ValueType> values, Dictionary<SuitType, int> suitCount)
        {
            return CheckForFlush(suitCount) && CheckForStraight(countOfValuesCount, values);
        }

        private static bool CheckForRoyalFlush(Dictionary<int, int> countOfValuesCount,
            List<ValueType> values, Dictionary<SuitType, int> suitCount)
        {
            return values.Contains(ValueType.Ace) &&
                   CheckForStraightFlush(countOfValuesCount, values, suitCount);
        }
    }





    public class PokerHand : IComparable<PokerHand>
    {
        public List<Card> Hand { get; }
        public PokerHandRank Rank { get; }

        public PokerHand(string hand)
        {
            Hand = ConvertToListOfTuple(hand);
            Hand.Sort();
            Rank = HandRanking.DetermineType(Hand);
            Hand = SortAceInLowStraights(Hand);
        }

        private List<Card> SortAceInLowStraights(List<Card> hand)
        {
            List<Card> result = new List<Card>();
            if (Rank == PokerHandRank.LowStraight || Rank == PokerHandRank.LowStraightFlush)
            {
                result.AddRange(hand.GetRange(1, 4));
                result.Add(hand[0]);
            }
            else
            {
                result = hand;
            }

            return result;
        }

        private List<Card> ConvertToListOfTuple(string hand)
        {
            return hand.Split(' ').ToList().ConvertAll(s => new Card(s[0], s[1]));
        }


        public int CompareTo(PokerHand other)
        {
            int result = Rank.CompareTo(other.Rank);
            if (result == 0)
            {
                for (int i = 0; i < 5 && result == 0; i++)
                    result = Hand[i].Value.CompareTo(other.Hand[i].Value);

                for (int i = 0; i < 5 && result == 0; i++)
                    result = Hand[i].Suit.CompareTo(other.Hand[i].Suit);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();
            foreach (Card card in Hand)
            {
                sr.Append(card.ToString());
            }

            return sr.ToString();
        }
    }
}

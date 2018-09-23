using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kata
{
    public enum ValueTypes
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

    public enum SuitTypes
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public class Card : IComparable<Card>
    {
        private string stringRepresentation;
        public ValueTypes Value { get; }
        public SuitTypes Suit { get; }
        public Dictionary<char, ValueTypes> ValueConversionDict = new Dictionary<char, ValueTypes>()
        {
            { 'A', ValueTypes.Ace},
            { 'K', ValueTypes.King},
            { 'Q', ValueTypes.Queen},
            { 'J', ValueTypes.Jack},
            { 'T', ValueTypes.Ten},
            { '9', ValueTypes.Nine},
            { '8', ValueTypes.Eight},
            { '7', ValueTypes.Seven},
            { '6', ValueTypes.Six},
            { '5', ValueTypes.Five},
            { '4', ValueTypes.Four},
            { '3', ValueTypes.Three},
            { '2', ValueTypes.Two}
        };
        public Dictionary<char, SuitTypes> SuitConversionDict = new Dictionary<char, SuitTypes>()
        {
            { 'S', SuitTypes.Spades},
            { 'H', SuitTypes.Hearts},
            { 'D', SuitTypes.Diamonds},
            { 'C', SuitTypes.Clubs}
        };

        public Card(char value, char suit)
        {
            stringRepresentation = $"{value}{suit}";
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
            return stringRepresentation;
        }
    }





    public enum PokerHandTypes
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
        HighCard,
        Null
    }

    public class PokerHandType
    {
        public PokerHandTypes Value { get; }

        public PokerHandType(List<Card> hand)
        {
            Value = DetermineType(hand);
        }

        private PokerHandTypes DetermineType(List<Card> hand)
        {
            PokerHandTypes result = PokerHandTypes.Null;

            hand.Sort();
            Dictionary<ValueTypes, int> valuesCount = DictOfCardValuesAndTheirCount(hand); ;
            Dictionary<int, int> countOfValuesCount = DictOfCountsAndCountsOfCounts(valuesCount); ;
            Dictionary<SuitTypes, int> suitCount = DictOfCardSuitsAndTheirCount(hand); ;

            //the most specif checks have to be performed first
            if (CheckForRoyalFlush(countOfValuesCount, valuesCount, suitCount))
                result = PokerHandTypes.RoyalFlush;
            else if (CheckForFourOfAKind(countOfValuesCount))
                result = PokerHandTypes.FourOfAKind;
            else if (CheckForStraightFlush(countOfValuesCount, valuesCount, suitCount))
                result = PokerHandTypes.StraightFlush;
            else if (CheckForLowStraightFlush(countOfValuesCount, valuesCount, suitCount))
                result = PokerHandTypes.LowStraightFlush;
            else if (CheckForFullHouse(countOfValuesCount))
                result = PokerHandTypes.FullHouse;
            else if (CheckForFlush(suitCount))
                result = PokerHandTypes.Flush;
            else if (CheckForStraight(countOfValuesCount, valuesCount))
                result = PokerHandTypes.Straight;
            else if (CheckForLowStraight(countOfValuesCount, valuesCount))
                result = PokerHandTypes.LowStraight;
            else if (CheckForThreeOfAKind(countOfValuesCount))
                result = PokerHandTypes.ThreeOfAKind;
            else if (CheckForDoublePair(countOfValuesCount))
                result = PokerHandTypes.TwoPair;
            else if (CheckForPair(countOfValuesCount))
                result = PokerHandTypes.Pair;
            else if (CheckForHighCard(countOfValuesCount))
                result = PokerHandTypes.HighCard;

            return result;
        }

        private bool CheckForHighCard(Dictionary<int, int> countOfValuesCount)
        {
            bool result = false;

            if (countOfValuesCount.ContainsKey(1))
                if (countOfValuesCount[1] == 5)
                    result = true;

            return result;
        }

        private bool CheckForPair(Dictionary<int, int> countOfValuesCount)
        {
            bool result = false;

            if (countOfValuesCount.ContainsKey(2) && !countOfValuesCount.ContainsKey(3))
                if (countOfValuesCount[2] == 1)
                    result = true;

            return result;
        }

        private bool CheckForDoublePair(Dictionary<int, int> countOfValuesCount)
        {
            bool result = false;

            if (countOfValuesCount.ContainsKey(2))
                if (countOfValuesCount[2] == 2)
                    result = true;

            return result;
        }

        private bool CheckForThreeOfAKind(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(3) && !countOfValuesCount.ContainsKey(2);
        }

        private bool CheckForFourOfAKind(Dictionary<int, int> countOfValuesCount)
        {
            bool result = false;

            if (countOfValuesCount.ContainsKey(4))
                if (countOfValuesCount[4] == 1)
                    result = true;

            return result;
        }

        private bool CheckForLowStraight(Dictionary<int, int> countOfValuesCount, Dictionary<ValueTypes, int> valuesCount)
        {
            bool result = false;
            if (CheckForHighCard(countOfValuesCount))
            {
                bool hasAce = valuesCount.ContainsKey(ValueTypes.Ace);
                var values = valuesCount.Keys.ToList();

                if (hasAce)
                {
                    values.Remove(ValueTypes.Ace);
                    if (values[3] - values[0] == 3)
                        if (values[3] == ValueTypes.Two)
                            result = true;
                }
            }

            return result;
        }

        private bool CheckForStraight(Dictionary<int, int> countOfValuesCount, Dictionary<ValueTypes, int> valuesCount)
        {
            bool result = false;
            if (CheckForHighCard(countOfValuesCount))
            {
                bool hasAce = valuesCount.ContainsKey(ValueTypes.Ace);
                var values = valuesCount.Keys.ToList();

                if (hasAce)
                {
                    values.Remove(ValueTypes.Ace);
                    if (values[3] - values[0] == 3)
                        if (values[0] == ValueTypes.King)
                            result = true;
                }
                else
                {
                    if (values[4] - values[0] == 4)
                        result = true;
                }

            }

            return result;
        }

        private bool CheckForFullHouse(Dictionary<int, int> countOfValuesCount)
        {
            return countOfValuesCount.ContainsKey(3) && countOfValuesCount.ContainsKey(2);
        }

        private bool CheckForFlush(Dictionary<SuitTypes, int> suitCount)
        {
            return suitCount.ContainsValue(5);
        }

        private bool CheckForLowStraightFlush(Dictionary<int, int> countOfValuesCount, Dictionary<ValueTypes, int> valuesCount, Dictionary<SuitTypes, int> suitCount)
        {
            return CheckForFlush(suitCount) && CheckForLowStraight(countOfValuesCount, valuesCount);
        }

        private bool CheckForStraightFlush(Dictionary<int, int> countOfValuesCount, Dictionary<ValueTypes, int> valuesCount, Dictionary<SuitTypes, int> suitCount)
        {
            return CheckForFlush(suitCount) && CheckForStraight(countOfValuesCount, valuesCount);
        }

        private bool CheckForRoyalFlush(Dictionary<int, int> countOfValuesCount, Dictionary<ValueTypes, int> valuesCount, Dictionary<SuitTypes, int> suitCount)
        {
            bool result = false;
            if (CheckForHighCard(countOfValuesCount) && CheckForFlush(suitCount))
            {
                bool hasAce = valuesCount.ContainsKey(ValueTypes.Ace);
                var values = valuesCount.Keys.ToList();

                if (hasAce)
                {
                    values.Remove(ValueTypes.Ace);
                    if (values[3] - values[0] == 3 && values[3] == ValueTypes.Ten)
                        result = true;
                }
            }

            return result;
        }

        private static Dictionary<ValueTypes, int> DictOfCardValuesAndTheirCount(List<Card> hand)
        {
            Dictionary<ValueTypes, int> valuesCount = new Dictionary<ValueTypes, int>();
            foreach (Card card in hand)
            {
                if (valuesCount.ContainsKey(card.Value))
                {
                    valuesCount[card.Value]++;
                }
                else
                {
                    valuesCount.Add(card.Value, 1);
                }
            }

            return valuesCount;
        }

        private static Dictionary<int, int> DictOfCountsAndCountsOfCounts(Dictionary<ValueTypes, int> valuesCount)
        {
            return valuesCount.GroupBy(p => p.Value).ToDictionary(x => x.Key, x => x.Count());
        }

        private Dictionary<SuitTypes, int> DictOfCardSuitsAndTheirCount(List<Card> hand)
        {
            Dictionary<SuitTypes, int> suitsCount = new Dictionary<SuitTypes, int>();
            foreach (Card card in hand)
            {
                if (suitsCount.ContainsKey(card.Suit))
                {
                    suitsCount[card.Suit]++;
                }
                else
                {
                    suitsCount.Add(card.Suit, 1);
                }
            }

            return suitsCount;
        }
    }





    public class PokerHand : IComparable<PokerHand>
    {
        public List<Card> Hand { get; }
        public PokerHandType Type { get; }

        public PokerHand(string hand)
        {
            Hand = ConvertToListOfTuple(hand);
            Hand.Sort();
            Type = new PokerHandType(Hand);
            Hand = SortAceInLowStraights(Hand);
        }

        private List<Card> SortAceInLowStraights(List<Card> hand)
        {
            List<Card> result = new List<Card>();
            if (Type.Value == PokerHandTypes.LowStraight || Type.Value == PokerHandTypes.LowStraightFlush)
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
            List<Card> result = hand.Split(' ').ToList().ConvertAll(s => new Card(s[0], s[1]));
            return result;
        }


        public int CompareTo(PokerHand other)
        {
            int result = Type.Value.CompareTo(other.Type.Value);
            if (result == 0)
            {
                for (int i = 0; i < 5 && result == 0; i++)
                {
                    result = Hand[i].Value.CompareTo(other.Hand[i].Value);

                }
                for (int i = 0; i < 5 && result == 0; i++)
                {
                    result = Hand[i].Suit.CompareTo(other.Hand[i].Suit);

                }
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

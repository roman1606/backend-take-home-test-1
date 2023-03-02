using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public class Hand
    {
        public List<Card> _cards { get; set; }

        public Hand(List<Card> cards)
        {
            _cards = cards;
        }

        public int GetRank()
        {
            // Evaluate the category of the hand
            if (IsFlush())
            {
                return 5;
            }
            else if (IsThreeOfAKind())
            {
                return 4;
            }
            else if (IsTwoPairs())
            {
                return 3;
            }
            else if (IsPair())
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public bool IsFlush()
        {
            return _cards.GroupBy(card => card._suit).Count() == 1;
        }

        public bool IsThreeOfAKind()
        {
            return _cards.GroupBy(card => card._value).Any(group => group.Count() == 3);
        }

        public bool IsTwoPairs()
        {
            return _cards.GroupBy(card => card._value).Count(group => group.Count() == 2) == 2;
        }

        public bool IsPair()
        {
            return _cards.GroupBy(card => card._value).Any(group => group.Count() == 2);
        }

        public int GetHighCardValue()
        {
            return _cards.Max(card => (int)card._value);
        }

        public int GetPairValue()
        {
            return _cards.GroupBy(card => card._value).Where(group => group.Count() == 2)
                        .Select(group => (int)group.Key).Max();
        }

        public List<int> GetTwoPairValues()
        {
            return _cards.GroupBy(card => card._value).Where(group => group.Count() == 2)
                        .Select(group => (int)group.Key).OrderByDescending(value => value).ToList();
        }

        public int GetThreeOfAKindValue()
        {
            return _cards.GroupBy(card => card._value).Where(group => group.Count() == 3)
                        .Select(group => (int)group.Key).Max();
        }

        public int GetFlushHighCardValue()
        {
            return (int)_cards.OrderByDescending(card => (int)card._value).First()._value;
        }

        public int GetRankValue()
        {
            switch (GetRank())
            {
                case 2: // Pair
                    return GetPairValue();
                case 3: // Two pairs
                    return GetTwoPairValues()[0] * 100 + GetTwoPairValues()[1];
                case 4: // Three of a kind
                    return GetThreeOfAKindValue();
                case 5: // Flush
                    return GetFlushHighCardValue();
                default: // High card
                    return GetHighCardValue();
            }
        }

        public int GetCount()
        {
            return _cards.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public class CompareHands
    {
        public static string Compare(Hand black, Hand white)
        {
            int blackRank = black.GetRankValue();
            int whiteRank = white.GetRankValue();

            if (blackRank > whiteRank)
            {
                return "BLACK WINS";
            }
            else if (blackRank < whiteRank)
            {
                return "WHITE WINS";
            }
            else // Same rank
            {
                switch (blackRank)
                {
                    case 1: // High card
                        int blackHighCard = black.GetHighCardValue();
                        int whiteHighCard = white.GetHighCardValue();
                        if (blackHighCard > whiteHighCard)
                        {
                            return "BLACK WINS";
                        }
                        else if (blackHighCard < whiteHighCard)
                        {
                            return "WHITE WINS";
                        }
                        else
                        {
                            return "TIE";
                        }
                    case 2: // Pair
                        int blackPair = black.GetPairValue();
                        int whitePair = white.GetPairValue();
                        if (blackPair > whitePair)
                        {
                            return "BLACK WINS";
                        }
                        else if (blackPair < whitePair)
                        {
                            return "WHITE WINS";
                        }
                        else // Same pair
                        {
                            return CompareHighCards(black, white);
                        }
                    case 3: // Two pairs
                        var blackPairs = black.GetTwoPairValues();
                        var whitePairs = white.GetTwoPairValues();
                        if (blackPairs[0] > whitePairs[0])
                        {
                            return "BLACK WINS";
                        }
                        else if (blackPairs[0] < whitePairs[0])
                        {
                            return "WHITE WINS";
                        }
                        else if (blackPairs[1] > whitePairs[1])
                        {
                            return "BLACK WINS";
                        }
                        else if (blackPairs[1] < whitePairs[1])
                        {
                            return "WHITE WINS";
                        }
                        else // Same two pairs
                        {
                            return CompareHighCards(black, white);
                        }
                    case 4: // Three of a kind
                        int blackThreeOfAKind = black.GetThreeOfAKindValue();
                        int whiteThreeOfAKind = white.GetThreeOfAKindValue();
                        if (blackThreeOfAKind > whiteThreeOfAKind)
                        {
                            return "BLACK WINS";
                        }
                        else if (blackThreeOfAKind < whiteThreeOfAKind)
                        {
                            return "WHITE WINS";
                        }
                        else
                        {
                            return CompareHighCards(black, white);
                        }
                    case 5: // Flush
                        int blackFlush = black.GetFlushHighCardValue();
                        int whiteFlush = white.GetFlushHighCardValue();
                        if (blackFlush > whiteFlush)
                        {
                            return "BLACK WINS";
                        }
                        else if (blackFlush < whiteFlush)
                        {
                            return "WHITE WINS";
                        }
                        else
                        {
                            return CompareHighCards(black, white);
                        }
                    default:
                        throw new Exception("Invalid rank");
                }
            }
        }

        public static string CompareHighCards(Hand black, Hand white)
        {
            var numCardsToCompare = Math.Min(black.GetCount(), white.GetCount());

            for (var i = 0; i < numCardsToCompare; i++)
            {
                var blackCardValue = black._cards.OrderByDescending(card => (int)card._value).ElementAt(i)._value;
                var whiteCardValue = white._cards.OrderByDescending(card => (int)card._value).ElementAt(i)._value;

                if (blackCardValue > whiteCardValue)
                {
                    return "BLACK WINS";
                }
                else if (whiteCardValue > blackCardValue)
                {
                    return "WHITE WINS";
                }
            }

            return "TIE";
        }

        public static string ComparePairs(Hand black, Hand white)
        {
            int blackPairValue = black.GetPairValue();
            int whitePairValue = white.GetPairValue();

            if (blackPairValue > whitePairValue)
            {
                return "BLACK WINS";
            }
            else if (whitePairValue > blackPairValue)
            {
                return "WHITE WINS";
            }
            else // same pair value
            {
                List<Card> blackRemainingCards = black._cards.Where(card => (int)card._value != blackPairValue).ToList();
                List<Card> whiteRemainingCards = white._cards.Where(card => (int)card._value != whitePairValue).ToList();

                return CompareHighCards(new Hand(blackRemainingCards), new Hand(whiteRemainingCards));
            }
        }

        public static string CompareTwoPair(Hand black, Hand white)
        {
            var blackPairs = black._cards.GroupBy(card => card._value).Where(g => g.Count() == 2).Select(g => g.Key).ToList();
            var whitePairs = white._cards.GroupBy(card => card._value).Where(g => g.Count() == 2).Select(g => g.Key).ToList();

            if (blackPairs.Max() > whitePairs.Max())
            {
                return "BLACK WINS";
            }
            else if (whitePairs.Max() > blackPairs.Max())
            {
                return "WHITE WINS";
            }
            else if (blackPairs.Min() > whitePairs.Min())
            {
                return "BLACK WINS";
            }
            else if (whitePairs.Min() > blackPairs.Min())
            {
                return "WHITE WINS";
            }
            else if (black._cards.Max(card => (int)card._value) > white._cards.Max(card => (int)card._value))
            {
                return "BLACK WINS";
            }
            else if (white._cards.Max(card => (int)card._value) > black._cards.Max(card => (int)card._value))
            {
                return "WHITE WINS";
            }
            else
            {
                return "TIE";
            }
        }

        public static string CompareThreeKind(Hand black, Hand white)
        {
            int blackThreeKindValue = black.GetThreeOfAKindValue();
            int whiteThreeKindValue = white.GetThreeOfAKindValue();

            if (blackThreeKindValue > whiteThreeKindValue)
            {
                return "BLACK WINS";
            }
            else if (blackThreeKindValue < whiteThreeKindValue)
            {
                return "WHITE WINS";
            }
            else
            {
                return CompareHighCards(black, white);
            }
        }

        public static string CompareFlush(Hand black, Hand white)
        {
            int blackFlushHighCard = black.GetFlushHighCardValue();
            int whiteFlushHighCard = white.GetFlushHighCardValue();

            if (blackFlushHighCard > whiteFlushHighCard)
            {
                return "BLACK WINS";
            }
            else if (whiteFlushHighCard > blackFlushHighCard)
            {
                return "WHITE WINS";
            }
            else
            {
                return CompareHighCards(black, white);
            }
        }



    }
}

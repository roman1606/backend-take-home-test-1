using FluentAssertions;
using PokerHand;

namespace PokerHandTest
{
    public class CompareHandsTest
    {
        /// <summary>
        /// Compare High Cards 
        /// </summary>
        [Fact]
        public void CompareHighCards_ShouldReturnBlackWins_WhenBlackHasHigherHighCard()
        {
            // Arrange
            var black = new Hand(new List<Card>
            {
                new Card(Suit.Hearts, Value.King),
                new Card(Suit.Diamonds, Value.Queen),
                new Card(Suit.Clubs, Value.Two),
                new Card(Suit.Spades, Value.Nine),
                new Card(Suit.Hearts, Value.Seven),
            });

            var white = new Hand(new List<Card>
            {
                new Card(Suit.Clubs, Value.King),
                new Card(Suit.Hearts, Value.Jack),
                new Card(Suit.Spades, Value.Three),
                new Card(Suit.Clubs, Value.Six),
                new Card(Suit.Diamonds, Value.Seven),
            });

            // Act
            string result = PokerHand.CompareHands.CompareHighCards(black, white);

            // Assert
            result.Should().Be("BLACK WINS");
        }

        [Fact]
        public void CompareHighCards_ShouldReturnWhiteWins_WhenWhiteHasHigherHighCard()
        {
            // Arrange
            var black = new Hand(new List<Card>
            {
                new Card(Suit.Clubs, Value.Two),
                new Card(Suit.Spades, Value.Eight),
                new Card(Suit.Hearts, Value.King),
                new Card(Suit.Diamonds, Value.Jack),
                new Card(Suit.Hearts, Value.Seven),
            });

            var white = new Hand(new List<Card>
            {
                new Card(Suit.Diamonds, Value.King),
                new Card(Suit.Clubs, Value.Jack),
                new Card(Suit.Hearts, Value.Queen),
                new Card(Suit.Spades, Value.Four),
                new Card(Suit.Clubs, Value.Seven),
            });

            // Act
            string result = PokerHand.CompareHands.CompareHighCards(black, white);

            // Assert
            result.Should().Be("WHITE WINS");
        }

        [Fact]
        public void CompareHighCards_ShouldReturnTie_WhenBothHandsHaveSameHighCard()
        {
            // Arrange
            var black = new Hand(new List<Card>
            {
                new Card(Suit.Clubs, Value.Ace),
                new Card(Suit.Spades, Value.King),
                new Card(Suit.Hearts, Value.Queen),
                new Card(Suit.Diamonds, Value.Jack),
                new Card(Suit.Clubs, Value.Ten),
            });

            var white = new Hand(new List<Card>
            {
                new Card(Suit.Diamonds, Value.Ace),
                new Card(Suit.Clubs, Value.King),
                new Card(Suit.Hearts, Value.Queen),
                new Card(Suit.Spades, Value.Jack),
                new Card(Suit.Diamonds, Value.Ten),
            });

            // Act
            string result = PokerHand.CompareHands.CompareHighCards(black, white);

            // Assert
            result.Should().Be("TIE");
        }

        /// <summary>
        /// Compare Single Pair
        /// </summary>
        [Fact]
        public void ComparePairs_ShouldReturnBlackWin_WhenBlackHasHigherPair()
        {
            // Arrange
            var black = new Hand(new List<Card>
            {
                new Card(Suit.Clubs, Value.Ace),
                new Card(Suit.Hearts, Value.Ace),
                new Card(Suit.Spades, Value.Four),
                new Card(Suit.Diamonds, Value.Five),
                new Card(Suit.Clubs, Value.Seven)
            });
            var white = new Hand(new List<Card>
            {
                new Card(Suit.Diamonds, Value.King),
                new Card(Suit.Spades, Value.King),
                new Card(Suit.Clubs, Value.Four),
                new Card(Suit.Hearts, Value.Five),
                new Card(Suit.Diamonds, Value.Seven)
            });

            // Act
            var result = PokerHand.CompareHands.ComparePairs(black, white);

            // Assert
            result.Should().Be("BLACK WINS");
        }

        /// <summary>
        /// Compare Two Pairs
        /// </summary>

        [Fact]
        public void CompareTwoPairs_BlackWinsWithHigherHighPair()
        {
            // Arrange
            var blackCards = new List<Card>
            {
                new Card(Suit.Diamonds, Value.Ace),
                new Card(Suit.Spades, Value.Ace),
                new Card(Suit.Clubs, Value.Four),
                new Card(Suit.Hearts, Value.Four),
                new Card(Suit.Diamonds, Value.Seven)
            };
            var black = new Hand(blackCards);

            var whiteCards = new List<Card>
            {
                new Card(Suit.Clubs, Value.King),
                new Card(Suit.Hearts, Value.King),
                new Card(Suit.Spades, Value.Four),
                new Card(Suit.Diamonds, Value.Four),
                new Card(Suit.Clubs, Value.Seven)
            };
            var white = new Hand(whiteCards);

            // Act
            var result = PokerHand.CompareHands.CompareTwoPair(black, white);

            // Assert
            result.Should().Be("BLACK WINS");
        }

        [Fact]
        public void CompareTwoPairs_BlackWinsWithHigherLowerPair()
        {
            // Arrange
            var blackCards = new List<Card>
            {
                new Card(Suit.Diamonds, Value.Ace),
                new Card(Suit.Spades, Value.Ace),
                new Card(Suit.Clubs, Value.Five),
                new Card(Suit.Hearts, Value.Five),
                new Card(Suit.Diamonds, Value.Seven)
            };
            var black = new Hand(blackCards);

            var whiteCards = new List<Card>
            {
                new Card(Suit.Clubs, Value.Ace),
                new Card(Suit.Hearts, Value.Ace),
                new Card(Suit.Spades, Value.Four),
                new Card(Suit.Diamonds, Value.Four),
                new Card(Suit.Clubs, Value.Seven)
            };
            var white = new Hand(whiteCards);

            // Act
            var result = PokerHand.CompareHands.CompareTwoPair(black, white);

            // Assert
            result.Should().Be("BLACK WINS");
        }


        /// <summary>
        /// Compare Three Kinds
        /// </summary>
        [Fact]
        public void CompareThreeKind_ShouldReturnBlackWins_WhenBlackHasHigherThreeKind()
        {
            // Arrange
            var blackHand = new Hand(new List<Card>
            {
                new Card(Suit.Clubs, Value.Ace),
                new Card(Suit.Spades, Value.Ace),
                new Card(Suit.Hearts, Value.Ace),
                new Card(Suit.Diamonds, Value.Eight),
                new Card(Suit.Clubs, Value.Five)
            });

            var whiteHand = new Hand(new List<Card>
            {
                new Card(Suit.Spades, Value.King),
                new Card(Suit.Clubs, Value.King),
                new Card(Suit.Hearts, Value.King),
                new Card(Suit.Diamonds, Value.Jack),
                new Card(Suit.Clubs, Value.Five)
            });

            // Act
            var result = PokerHand.CompareHands.CompareThreeKind(blackHand, whiteHand);

            // Assert
            result.Should().Be("BLACK WINS");
        }

        /// <summary>
        /// Compare Flushes
        /// </summary>
        [Fact]
        public void CompareFlush_ShouldReturnBlackWins_WhenBlackHasHigherFlush()
        {
            // Arrange
            var blackCards = new List<Card>
            {
                new Card(Suit.Hearts, Value.Ace),
                new Card(Suit.Hearts, Value.Ten),
                new Card(Suit.Hearts, Value.Six),
                new Card(Suit.Hearts, Value.Five),
                new Card(Suit.Hearts, Value.Three)
            };
            var whiteCards = new List<Card>
            {
                new Card(Suit.Spades, Value.King),
                new Card(Suit.Spades, Value.Queen),
                new Card(Suit.Spades, Value.Jack),
                new Card(Suit.Spades, Value.Ten),
                new Card(Suit.Spades, Value.Six)
            };
            var blackHand = new Hand(blackCards);
            var whiteHand = new Hand(whiteCards);

            // Act
            var result = PokerHand.CompareHands.CompareFlush(blackHand, whiteHand);

            // Assert
            result.Should().Be("BLACK WINS");
        }

        public void CompareFlushVsTwoPair_ShouldReturnBlackWins_WhenBlackHasFlush()
        {
            // Arrange
            var blackCards = new List<Card>
            {
                new Card(Suit.Hearts, Value.Ace),
                new Card(Suit.Hearts, Value.Ten),
                new Card(Suit.Hearts, Value.Six),
                new Card(Suit.Hearts, Value.Five),
                new Card(Suit.Hearts, Value.Three)
            };
            var whiteCards = new List<Card>
            {
                new Card(Suit.Spades, Value.King),
                new Card(Suit.Diamonds, Value.King),
                new Card(Suit.Spades, Value.Jack),
                new Card(Suit.Clubs, Value.Jack),
                new Card(Suit.Diamonds, Value.Six)
            };
            var blackHand = new Hand(blackCards);
            var whiteHand = new Hand(whiteCards);

            // Act
            var result = PokerHand.CompareHands.CompareFlush(blackHand, whiteHand);

            // Assert
            result.Should().Be("BLACK WINS");
        }
    }
}
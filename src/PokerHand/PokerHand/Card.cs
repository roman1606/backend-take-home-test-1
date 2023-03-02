

namespace PokerHand
{
    public class Card
    {
        public Suit _suit { get; set; }
        public Value _value { get; set; }

        public Card(Suit suit, Value value)
        {
            _suit = suit;
            _value = value;
        }

        public override string ToString()
        {
            return $"{_value}{_suit}";
        }
    }
}

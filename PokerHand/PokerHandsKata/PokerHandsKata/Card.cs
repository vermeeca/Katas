using System;

namespace PokerHandsKata
{
    public class Card : IComparable
    {
        public const int VALUES = 13;
        public const int SUITS = 4;

        public CardValue Value { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;

        }

        public int CompareTo(object obj)
        {
            var other = obj as Card;
            
            return other != null ? Value.CompareTo(other.Value) : 1;
        }
    }
}
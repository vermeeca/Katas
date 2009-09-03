using System;

namespace PokerHandsKata
{
    public class Hand : IComparable
    {

        public string[] Cards { get; private set; }

        public Hand(string[] cards)
        {
            Cards = cards;
        }

        public Hand(string s) : this(s.Split(' '))
        {
            
        }


        public int CompareTo(Hand other)
        {
            return 0;
        }

        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}
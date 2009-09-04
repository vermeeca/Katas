using System;
using System.Collections.Generic;

namespace PokerHandsKata
{
    public class SuitParser
    {

        private static Dictionary<string, CardSuit> _map = new Dictionary<string, CardSuit>
            {
                {"H", CardSuit.Hearts},
                {"D", CardSuit.Diamonds},
                {"S", CardSuit.Spades},
                {"C", CardSuit.Clubs}
            };

        public CardSuit Parse(string value)
        {
            return _map[value.ToUpper()];
        }
    }

    
}
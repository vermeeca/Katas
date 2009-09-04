using System;
using System.Collections.Generic;

namespace PokerHandsKata
{
    public class ValueParser
    {

        private static readonly Dictionary<string, CardValue> _map = new Dictionary<string,CardValue>                                                                       
        {
            {"2", CardValue.Two},
            {"3", CardValue.Three},
            {"4", CardValue.Four},
            {"5", CardValue.Five},
            {"6", CardValue.Six},
            {"7", CardValue.Seven},
            {"8", CardValue.Eight},
            {"9", CardValue.Nine},
            {"10", CardValue.Ten},
            {"J", CardValue.Jack},
            {"Q", CardValue.Queen},
            {"K", CardValue.King},
            {"A", CardValue.Ace}
                                                                             
        };

        public CardValue Parse(string value)
        {
            return _map[value.ToUpper()];
        }
    }
}
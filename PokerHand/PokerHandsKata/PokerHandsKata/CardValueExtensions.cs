using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsKata
{
    public static class CardValueExtensions
    {
        public static int Score(this CardValue value)
        {
            var sum = (from v in (CardValue[]) Enum.GetValues(typeof (CardValue))
                       where v < value
                       select v.Score()).Sum();

            return sum + (int) value;
                     
        }
    }
}

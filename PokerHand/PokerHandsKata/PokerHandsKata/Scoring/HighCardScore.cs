using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsKata.Scoring
{
    public class HighCardScore : ScoreBase<HighCardScore>
    {

        private CardValue _value;

        public HighCardScore(CardValue value)
        {
            _value = value;
        }

        protected override int CompareSameScoreType(HighCardScore other)
        {
            return this._value.CompareTo(other._value);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.HighCard; }
        }
    }
}

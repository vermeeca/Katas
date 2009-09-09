using System;

namespace PokerHandsKata.Scoring
{
    public class StraightFlushScore : ScoreBase<StraightFlushScore>
    {
        private CardValue _value;

        public StraightFlushScore(CardValue value)
        {
            _value = value;
        }

        protected override int CompareSameScoreType(StraightFlushScore other)
        {
            return this._value.CompareTo(other._value);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.StraightFlush; }
        }
    }
}
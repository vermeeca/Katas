using System;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Scoring
{
    public class PairScore : ScoreBase<PairScore>
    {
        public PairScore(CardValue value)
        {
            _value = value;
        }

        private CardValue _value;

        protected override int CompareSameScoreType(PairScore other)
        {
            return _value.CompareTo(other._value);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.Pair; }
        }
    }
}
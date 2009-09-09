using System;

namespace PokerHandsKata.Scoring
{
    public class FourOfAKindScore : ScoreBase<FourOfAKindScore>
    {
        private CardValue _value;

        public FourOfAKindScore(CardValue value)
        {
            _value = value;
        }

        protected override int CompareSameScoreType(FourOfAKindScore other)
        {
            return _value.CompareTo(other._value);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.FourOfAKind; }
        }
    }
}
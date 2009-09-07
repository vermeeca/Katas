using System;

namespace PokerHandsKata.Scoring
{
    public class ThreeOfAKindScore : ScoreBase<ThreeOfAKindScore>
    {
        public ThreeOfAKindScore(CardValue value)
        {
            _value = value;
        }

        private CardValue _value;

        protected override int CompareSameScoreType(ThreeOfAKindScore other)
        {
            return _value.CompareTo(other._value);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.ThreeOfAKind; }
        }
    }
}
using System;

namespace PokerHandsKata.Scoring
{
    public class FullHouseScore : ScoreBase<FullHouseScore>
    {
        private CardValue _three;
        private CardValue _two;

        public FullHouseScore(CardValue three, CardValue two)
        {
            _three = three;
            _two = two;
        }

        protected override int CompareSameScoreType(FullHouseScore other)
        {
            return _three.CompareTo(other._three) == 0 ? _two.CompareTo(other._two) : _three.CompareTo(other._three);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.FullHouse; }
        }
    }
}
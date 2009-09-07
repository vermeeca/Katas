using System;

namespace PokerHandsKata.Scoring
{
    public class FlushScore : ScoreBase<FlushScore>
    {

        private CardSuit _suit;
        private CardValue _highCard;

        public FlushScore(CardSuit suit, CardValue highCard)
        {
            _suit = suit;
            _highCard = highCard;
        }

        protected override int CompareSameScoreType(FlushScore other)
        {
            return new HighCardScore(_highCard).CompareTo(new HighCardScore(other._highCard));
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.Flush; }
        }
    }
}
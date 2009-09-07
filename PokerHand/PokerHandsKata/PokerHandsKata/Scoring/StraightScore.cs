namespace PokerHandsKata.Scoring
{
    public class StraightScore : ScoreBase<StraightScore>
    {

        private CardValue _highCard;

        public StraightScore(CardValue highCard)
        {
            _highCard = highCard;
        }

        protected override int CompareSameScoreType(StraightScore other)
        {
            return _highCard.CompareTo(other._highCard);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.Straight; }
        }
    }
}
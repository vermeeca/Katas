using System;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Scoring
{
    public class TwoPairScore : ScoreBase<TwoPairScore>
    {
        public TwoPairScore(CardValue pairOne, CardValue pairTwo)
        {

            if(pairOne == pairTwo)
            {
                throw new InvalidOperationException("This is four of a kind, silly.");
            }

            if(pairOne > pairTwo)
            {
                _highPair = pairOne;
                _lowPair = pairTwo;
            }
            else
            {
                _highPair = pairTwo;
                _lowPair = pairOne;
            }
        }

        private CardValue _highPair;
        private CardValue _lowPair;

        protected override int CompareSameScoreType(TwoPairScore other)
        {
            return _highPair.CompareTo(other._highPair) == 0
                       ? _lowPair.CompareTo(other._lowPair)
                       : _highPair.CompareTo(other._highPair);
        }

        public override ScoreClass Class
        {
            get { return ScoreClass.TwoPair; }
        }
    }
}
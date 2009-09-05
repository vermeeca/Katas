using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsKata.Scoring
{
    public class CompositeScore : IScore
    {

        private List<IScore> _scores = new List<IScore>();

        public void Add(IScore score)
        {
            _scores.Add(score);
        }

        private List<IScore> GetScoresSorted()
        {
            var returnVal = (from s in _scores
                             select s).ToList();
            returnVal.Sort();
            returnVal.Reverse();
            return returnVal;
        }

        public int CompareTo(IScore other)
        {
            var otherComp = other as CompositeScore;
            if(otherComp == null)
            {
                throw new InvalidOperationException("Composite Scores can only be compared to each other");
            }

            var mySortedScores = GetScoresSorted();
            var otherSortedScores = otherComp.GetScoresSorted();

            for(int i = 0; i < (mySortedScores.Count < otherSortedScores.Count ? mySortedScores.Count : otherSortedScores.Count); i++)
            {
                var result = mySortedScores[i].CompareTo(otherSortedScores[i]);
                if(result != 0)
                {
                    return result;
                }
            }

            //wha?
            throw new InvalidOperationException("I think I need to refactor this method");

        }

        //Hrm.  Think this means I have this at the wrong abstraction
        public ScoreClass Class
        {
            get { throw new NotImplementedException(); }
        }

        public int CompareTo(object obj)
        {
            return ((IComparable<IScore>) this).CompareTo(obj as IScore);
        }
    }
}
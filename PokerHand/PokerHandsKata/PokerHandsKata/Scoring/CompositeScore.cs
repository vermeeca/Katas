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

            //magic value.  argh
            var result = Int32.MinValue;
            for(int i = 0; i < (mySortedScores.Count < otherSortedScores.Count ? mySortedScores.Count : otherSortedScores.Count); i++)
            {
                result = mySortedScores[i].CompareTo(otherSortedScores[i]);
                if (result != 0)
                {
                    break;
                }
            }

            if (result == Int32.MinValue)
            {
                throw new InvalidOperationException("Should not have gotten here.");
            }

            return result;

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
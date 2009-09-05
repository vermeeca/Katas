using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsKata.Scoring
{
    public abstract class ScoreBase<TScoreType> : IScore where TScoreType:class
    {

        public int CompareTo(IScore other)
        {
            int classCompareResult = this.Class.CompareTo(other.Class);
            return classCompareResult == 0 ? CompareSameScoreType(other as TScoreType) : classCompareResult;
            
        }

        protected abstract int CompareSameScoreType(TScoreType other);

        public abstract ScoreClass Class{get;}

        public int CompareTo(object obj)
        {
            IScore other = obj as IScore;
            if(other == null)
            {
                throw new InvalidOperationException("Score objects can only be compared to other score objects");
            }

            return ((IComparable<IScore>) this).CompareTo(other);
        }
    }
}

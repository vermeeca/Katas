using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.HandEvaluation
{
    public class HandEvaluation
    {
        public Func<ValueSet, SuitSet, List<ValueSet>, bool> Condition { get; set; }
        public Func<ValueSet, SuitSet, List<ValueSet>, IScore> ScoreFactory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Scoring
{
    public interface IScore : IComparable<IScore> , IComparable
    {
        ScoreClass Class { get; }

    }
}

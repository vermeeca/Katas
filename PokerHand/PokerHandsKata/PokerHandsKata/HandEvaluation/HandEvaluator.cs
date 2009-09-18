using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandsKata;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.HandEvaluation
{
    public class HandEvaluator
    {
        
     

        public IScore Score(Hand hand)
        {
            var Cards = hand.Cards;
            CompositeScore handScore = new CompositeScore();

            var sets = (from c in Cards
                        group c by c.Value
                        into g
                            orderby g.Key
                            select new ValueSet{ Value = g.Key, Count = g.Count() }).ToList();

            var suits = (from c in Cards
                         group c by c.Suit
                         into g
                             where g.Count() == 5
                             select new SuitSet {Suit = g.Key, Count = g.Count(), High = g.Max(c => c.Value)}).
                FirstOrDefault();



            //linq-terbation?
            var scores = (from m in HandEvaluationMap.Map
                         from s in sets
                         where m.Condition(s, suits, sets)
                         select m.ScoreFactory(s, suits, sets)).ToList();


            scores.ForEach(handScore.Add);
            
            return handScore;
        }
    }
}
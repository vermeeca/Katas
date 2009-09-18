using System.Collections.Generic;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.HandEvaluation
{
    public static class HandEvaluationMap
    {

        public static List<HandEvaluation> Map = null;

        static HandEvaluationMap()
        {
            Map = new List<HandEvaluation>
                      {
                          HighCard,
                          Pair,
                          TwoPair,
                          ThreeOfAKind,
                          FullHouse,
                          FourOfAKind,
                          Flush,
                          Straight,
                          StraightFlush
                      };
        }


        private static readonly HandEvaluation HighCard =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => val.Count == 1,
                    ScoreFactory = (val, suit, allV) => new HighCardScore(val.Value)
                };

        private static readonly HandEvaluation Pair =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => val.Count == 2 &&
                                                     allV.FindLast(s => s.Count == 2 && !object.ReferenceEquals(val, s)) ==
                                                     null,
                    ScoreFactory = (val, suit, allV) => new PairScore(val.Value)
                };

        private static readonly HandEvaluation TwoPair =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => val.Count == 2 &&
                                                     allV.FindLast(s => s.Count == 2 && !object.ReferenceEquals(val, s)) !=
                                                     null,
                    ScoreFactory =
                        (val, suit, allV) =>
                        new TwoPairScore(val.Value,
                                         allV.FindLast(s => s.Count == 2 && !object.ReferenceEquals(val, s)).Value)
                };

        private static readonly HandEvaluation ThreeOfAKind =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => val.Count == 3 && allV.FindLast((s) => s.Count == 2) == null,
                    ScoreFactory = (val, suit, allV) => new ThreeOfAKindScore(val.Value)
                };

        private static readonly HandEvaluation FullHouse = 
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => val.Count == 3 && allV.FindLast((s) => s.Count == 2) != null,
                    ScoreFactory = (val, suit, allV) => new FullHouseScore(val.Value,allV.FindLast((s) => s.Count == 2).Value )
                };

        private static readonly HandEvaluation FourOfAKind =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => val.Count == 4,
                    ScoreFactory = (val, suit, allV) => new FourOfAKindScore(val.Value)
                };

        private static readonly HandEvaluation Flush =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => suit != null && val.Count < 5,
                    ScoreFactory = (val, suit, allV) => new FlushScore(suit == null ? CardSuit.Clubs : suit.Suit, suit == null ? CardValue.Two : suit.High)
                };

        private static readonly HandEvaluation Straight =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => (allV.Count == 5 && ((allV[4].Value - allV[0].Value) == 4)) && suit == null,
                    ScoreFactory = (val, suit, allV) => new StraightScore(allV[4].Value)
                };

        private static readonly HandEvaluation StraightFlush =
            new HandEvaluation
                {
                    Condition = (val, suit, allV) => (allV.Count == 5 && ((allV[4].Value - allV[0].Value) == 4)) && suit != null,
                    ScoreFactory = (val, suit, allV) => new StraightFlushScore(allV[4].Value)
                };


    
    }
}
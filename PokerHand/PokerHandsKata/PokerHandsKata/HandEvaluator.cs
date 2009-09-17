using System;
using System.Linq;
using PokerHandsKata.Scoring;

namespace PokerHandsKata
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
			            	select new { Value = g.Key, Count = g.Count() }).ToList();

			var suits = (from c in Cards
			             group c by c.Suit
			             into g
			             	where g.Count() == 5
			             	select new { Suit = g.Key, Count = g.Count(), High = g.Max(c => c.Value) }).ToList();

			foreach (var set in sets)
			{
				switch (set.Count)
				{
					case 4:
						handScore.Add(new FourOfAKindScore(set.Value));
						break;
					case 3:
						var pairAlso = sets.FindLast((s) => s.Count == 2);
						if (pairAlso == null)
						{
							handScore.Add(new ThreeOfAKindScore(set.Value));
						}
						else
						{
							handScore.Add(new FullHouseScore(set.Value, pairAlso.Value));
						}
						break;
					case 2:
						var otherPair = sets.FindLast(s => s.Count == 2 && !object.ReferenceEquals(set, s));
						if (otherPair == null)
						{
							handScore.Add(new PairScore(set.Value));
						}
						else
						{
							handScore.Add(new TwoPairScore(set.Value, otherPair.Value));
						}
						break;
					case 1:
						handScore.Add(new HighCardScore(set.Value));
						break;

				}
			}

			if (sets.Count == 5 && ((sets[4].Value - sets[0].Value) == 4))
			{
				if (suits.Count == 1)
				{
					handScore.Add(new StraightFlushScore(suits[0].High));
				}
				else
				{
					handScore.Add(new StraightScore(sets[4].Value));
				}
			}

			if (suits.Count == 1)
			{
				handScore.Add(new FlushScore(suits[0].Suit, suits[0].High));
			}

			return handScore;
		}
	}
}
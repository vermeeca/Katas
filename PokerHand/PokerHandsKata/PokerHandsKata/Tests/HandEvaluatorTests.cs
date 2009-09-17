using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests
{
	[TestFixture]
	public class HandEvaluatorTests
	{
		private CompositeScore Score(string handString)
		{
			var hand = new Hand(handString);
			return (CompositeScore)(new HandEvaluator().Score(hand));
		}

		[Test]
		public void OnlyHighCard()
		{
			var score = Score("2H 3S 4H 5S 7S");
			Assert.AreEqual(5, score.Scores.Count);
			Assert.IsTrue(score.Scores.TrueForAll(s => s is HighCardScore));
		}


		[TestCase("2H 2S 4H 5S 7S", typeof(PairScore))]
		[TestCase("2H 2S 4H 4S 7S", typeof(TwoPairScore))]
		[TestCase("2H 2S 2D 4S 7S", typeof(ThreeOfAKindScore))]
		[TestCase("2H 3S 4D 5S 6S", typeof(StraightScore))]
		[TestCase("2H 3H 4H 5H 7H", typeof(FlushScore))]
		[TestCase("2H 2D 2S 5H 5D", typeof(FullHouseScore))]
		[TestCase("2H 2D 2S 2C 5D", typeof(FourOfAKindScore))]
		[TestCase("2H 3H 4H 5H 6H", typeof(StraightFlushScore))]
		public void TestEvaluate(string hand, Type expected)
		{
			var score = Score(hand);
			Assert.IsNotNull(score.Scores.First(s => s.GetType().Equals(expected)));
		}
	}
}

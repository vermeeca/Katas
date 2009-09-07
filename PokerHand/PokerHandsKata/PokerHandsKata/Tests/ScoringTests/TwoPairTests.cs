using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class TwoPairTests
    {
        [Test]
        public void Highest_Pair_Should_Win()
        {
            var high = new TwoPairScore(CardValue.Two, CardValue.Four);
            var low = new TwoPairScore(CardValue.Two, CardValue.Three);

            Assert.Greater(high, low);
        }

        [Test]
        public void Lower_Of_High_Should_Lose()
        {
            var high = new TwoPairScore(CardValue.Two, CardValue.Four);
            var low = new TwoPairScore(CardValue.Two, CardValue.Three);

            Assert.Less(low, high);
        }

        [Test]
        public void Second_Pair_Should_Break_Tie()
        {
            var high = new TwoPairScore(CardValue.Three, CardValue.Four);
            var low = new TwoPairScore(CardValue.Two, CardValue.Four);

            Assert.Greater(high, low);
        }

        [Test]
        public void Same_Two_Pairs_Should_Tie()
        {
            var high = new TwoPairScore(CardValue.Three, CardValue.Four);
            var low = new TwoPairScore(CardValue.Three, CardValue.Four);

            Assert.AreEqual(0, high.CompareTo(low));
        }

        [Test]
        public void Should_Always_Beat_One_Pair()
        {
            var high = new TwoPairScore(CardValue.Three, CardValue.Four);
            var low = new PairScore(CardValue.Ace);

            Assert.Greater(high, low);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class PairTests
    {
        [Test]
        public void Should_Beat_Lower_Pair()
        {
            var high = new PairScore(CardValue.Three);
            var low = new PairScore(CardValue.Two);

            Assert.Greater(high, low, "Pair of threes should be pair of twos");

        }

        [Test]
        public void Should_Beat_Lower_Pair_2()
        {
            var high = new PairScore(CardValue.Three);
            var low = new PairScore(CardValue.Two);

            Assert.Less(low, high, "Pair of threes should be pair of twos");

        }

        [Test]
        public void Should_Tie_With_Same_Pair()
        {
            var high = new PairScore(CardValue.Two);
            var low = new PairScore(CardValue.Two);

            Assert.AreEqual(0, high.CompareTo(low), "Same pair should tie");

        }

        [Test]
        public void Should_Beat_HighCard()
        {
            var high = new PairScore(CardValue.Three);
            var low = new HighCardScore(CardValue.Ace);

            Assert.Greater(high, low, "Pair should beat high card");

        }
    }
}

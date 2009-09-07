using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class ThreeOfAKindTests
    {
        [Test]
        public void High_Three_Should_Win()
        {
            var high = new ThreeOfAKindScore(CardValue.Three);
            var low = new ThreeOfAKindScore(CardValue.Two);

            Assert.Greater(high, low);
        }

        [Test]
        public void Low_Three_Should_Lose()
        {
            var high = new ThreeOfAKindScore(CardValue.Three);
            var low = new ThreeOfAKindScore(CardValue.Two);

            Assert.Less(low, high);
        }

        [Test]
        public void Same_Three_Should_Tie()
        {
            var high = new ThreeOfAKindScore(CardValue.Three);
            var low = new ThreeOfAKindScore(CardValue.Three);

            Assert.AreEqual(0, high.CompareTo(low));
        }

        [Test]
        public void Should_Always_Beat_Two_Pair()
        {
            var high = new ThreeOfAKindScore(CardValue.Three);
            var low = new TwoPairScore(CardValue.Ace, CardValue.King);

            Assert.Greater(high, low);
        }
    }
}

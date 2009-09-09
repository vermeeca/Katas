using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class StraightFlushTests
    {

        [Test]
        public void Should_Always_Beat_FourOfAKind()
        {
            var high = new StraightFlushScore(CardValue.Six);
            var low = new FourOfAKindScore(CardValue.Ace);

            Assert.Greater(high, low);
        }

        [Test]
        public void Higher_Straight_Should_Win()
        {
            var high = new StraightFlushScore(CardValue.Seven);
            var low = new StraightFlushScore(CardValue.Six);

            Assert.Greater(high, low);
        }

        [Test]
        public void Lower_Straight_Should_Lose()
        {
            var high = new StraightFlushScore(CardValue.Seven);
            var low = new StraightFlushScore(CardValue.Six);

            Assert.Less(low, high);
        }
    }
}

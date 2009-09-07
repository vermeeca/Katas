using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class StraightTests
    {

        [Test]
        public void Should_Always_Beat_ThreeOfAKind()
        {
            var high = new StraightScore(CardValue.Six);
            var low = new ThreeOfAKindScore(CardValue.Ace);

            Assert.Greater(high, low);
        }

        [Test]
        public void Higher_Straight_Should_Win()
        {
            var high = new StraightScore(CardValue.Seven);
            var low = new StraightScore(CardValue.Six);

            Assert.Greater(high, low);
        }

        [Test]
        public void Lower_Straight_Should_Lose()
        {
            var high = new StraightScore(CardValue.Seven);
            var low = new StraightScore(CardValue.Six);

            Assert.Less(low, high);
        }
    }
}

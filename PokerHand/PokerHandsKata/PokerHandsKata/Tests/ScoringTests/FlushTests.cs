using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class FlushTests
    {
        [Test]
        public void Should_Always_Beat_Straight()
        {

            var high = new FlushScore(CardSuit.Clubs, CardValue.Two);
            var low = new StraightScore(CardValue.Ace);

            Assert.Greater(high, low);
        }

        [Test]
        public void Two_Flushes_Revert_To_HighCard_Rules()
        {
            var high = new FlushScore(CardSuit.Clubs, CardValue.Three);
            var low = new FlushScore(CardSuit.Diamonds, CardValue.Two);

            Assert.Greater(high, low);
        }

        [Test]
        public void Same_Flush_Should_Tie()
        {
            var high = new FlushScore(CardSuit.Clubs, CardValue.Three);
            var low = new FlushScore(CardSuit.Diamonds, CardValue.Three);

            Assert.AreEqual(0, high.CompareTo(low));
        }

    }
}

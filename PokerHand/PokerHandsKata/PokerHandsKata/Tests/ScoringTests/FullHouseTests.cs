using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class FullHouseTests
    {
        [Test]
        public void Should_Always_Beat_Flush()
        {
            var high = new FullHouseScore(CardValue.Two, CardValue.Three);
            var low = new FlushScore(CardSuit.Clubs, CardValue.Ace);

            Assert.Greater(high, low);
        }

        [Test]
        public void Higher_Threes_Should_Win()
        {
             var high = new FullHouseScore(CardValue.Three, CardValue.Two);
            var low = new FullHouseScore(CardValue.Two, CardValue.Three);

            Assert.Greater(high, low);
        }

        [Test]
        public void Lower_Threes_Should_Lose()
        {
            var high = new FullHouseScore(CardValue.Three, CardValue.Two);
            var low = new FullHouseScore(CardValue.Two, CardValue.Three);

            Assert.Less(low, high);
        }

        [Test]
        public void When_Threes_Tie_Use_Twos()
        {
            var high = new FullHouseScore(CardValue.Three, CardValue.Five);
            var low = new FullHouseScore(CardValue.Three, CardValue.Four);

            Assert.Greater(high, low);
        }

        [Test]
        public void Same_Pairs_Should_Tie_Even_Though_Impossible()
        {
            var high = new FullHouseScore(CardValue.Three, CardValue.Four);
            var low = new FullHouseScore(CardValue.Three, CardValue.Four);

            Assert.AreEqual(0, high.CompareTo(low));
        }
    }
}

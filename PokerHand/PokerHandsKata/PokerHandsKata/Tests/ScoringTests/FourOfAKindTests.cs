using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class FourOfAKindTests
    {

        [Test]
        public void Should_Always_Beat_FullHouse()
        {
            var high = new FourOfAKindScore(CardValue.Two);
            var low = new FullHouseScore(CardValue.Ace, CardValue.King);

            Assert.Greater(high, low);
        }

        [Test]
        public void Higher_Value_Should_Win()
        {
            var high = new FourOfAKindScore(CardValue.Three);
            var low = new FourOfAKindScore(CardValue.Two);

            Assert.Greater(high, low);
        }

        [Test]
        public void Lower_Value_Should_Lose()
        {
            var high = new FourOfAKindScore(CardValue.Three);
            var low = new FourOfAKindScore(CardValue.Two);

            Assert.Less(low, high);
        }


    }
}

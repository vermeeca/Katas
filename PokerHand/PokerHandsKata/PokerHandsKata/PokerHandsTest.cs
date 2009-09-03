using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PokerHandsKata
{
    [TestFixture]
    public class PokerHandsTest
    {
        [Test]
        public void Scenario1_WhiteWins()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2C 3H 4S 8C AH");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void Scenario2_BlackWins()
        {
            var whiteHand = new Hand("2H 4S 4C 2D 4H");
            var blackHand = new Hand("2S 8S AS QS 3S");

            Assert.Greater(blackHand, whiteHand, "Black should be the winner");
        }

        [Test]
        public void Scenario3_BlackWins()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2C 3H 4S 8C KH");

            Assert.Greater(blackHand, whiteHand, "Black should be the winner");
        }

        [Test]
        public void Scenario4_WhiteWins()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2D 3H 5C 9S KH");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }
    }
}

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
        public void HighCardWins()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2C 3H 4S 8C AH");

            Assert.Greater(blackHand, whiteHand, "Black should be the winner");
        }

        [Test]
        public void PairBeatsHighCard()
        {
            var whiteHand = new Hand("2H 4S 5C 2D 6H");
            var blackHand = new Hand("2S 8S AS QS 3S");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }


        [Test]
        public void FullHouseBeatsHighCard()
        {
            var whiteHand = new Hand("2H 4S 4C 2D 4H");
            var blackHand = new Hand("2S 8S AS QS 3S");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void HighCard2()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2C 3H 4S 8C KH");

            Assert.Greater(blackHand, whiteHand, "Black should be the winner");
        }

        [Test]
        public void Tie()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2D 3H 5C 9S KH");

            Assert.AreEqual(0, whiteHand.CompareTo(blackHand), "This hand should be a tie");
        }
    }
}

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
        public void HighCard2()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2C 3H 4S 8C KH");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void HighCard3()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2C 3H 4S 9C KH");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void HighCard4()
        {
            var whiteHand = new Hand("3H 4D 5S 9C KD");
            var blackHand = new Hand("2C 4H 5S 9C KH");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void PairBeatsHighCard()
        {
            var whiteHand = new Hand("2H 4S 5C 2D 6H");
            var blackHand = new Hand("2S 8S AS QS 3S");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void HighPairBeatsLowPair()
        {
            var whiteHand = new Hand("2H 4S 5C 2D 6H");
            var blackHand = new Hand("2S 8S AS QS 8S");

            Assert.Greater(blackHand, whiteHand, "Black should be the winner");
        }

        [Test]
        public void SamePairTakeHighCard()
        {
            var whiteHand = new Hand("2H QS KC 2D JH");
            var blackHand = new Hand("2S 8S AS QS 2S");

            Assert.Greater(blackHand, whiteHand, "Black should be the winner");
        }

        [Test]
        public void TwoPairBeatsOnePair()
        {
            var whiteHand = new Hand("2H 3S 3C 2D JH");
            var blackHand = new Hand("AS 8S 3S QS AS");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void TwoPairTakeHighestPair()
        {
            var whiteHand = new Hand("2H 5S 5C 2D JH");
            var blackHand = new Hand("2S 4S 4S 2S AS");

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
        public void Tie()
        {
            var whiteHand = new Hand("2H 3D 5S 9C KD");
            var blackHand = new Hand("2D 3H 5C 9S KH");

            Assert.AreEqual(0, whiteHand.CompareTo(blackHand), "This hand should be a tie");
        }
    }
}

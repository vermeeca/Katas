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
        public void HighCardTie()
        {
            var whiteHand = new Hand("3H 4D 5S 9C KD");
            var blackHand = new Hand("3C 4H 5S 9C KH");

            Assert.AreEqual(0, whiteHand.CompareTo(blackHand), "Should be a tie");
        }

        [Test]
        public void PairBeatsHighCard()
        {
            var whiteHand = new Hand("2H 4S 5C 2D 6H");
            var blackHand = new Hand("2S 8H AS QS 3S");

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
            var blackHand = new Hand("AS 8S 3H QS AS");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void TwoPairTakeHighestPair()
        {
            var whiteHand = new Hand("2H 5S 5C 2D JH");
            var blackHand = new Hand("2S 4S 4S 2H AS");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void SameTwoPairTakeHighestCard()
        {
            var whiteHand = new Hand("2H 5S 5C 2D AH");
            var blackHand = new Hand("2S 5H 5D 2S JS");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

        [Test]
        public void ThreeOfAKindBeatsTwoPair()
        {
            var high = new Hand("2H 2S 5C 2D AH");
            var low = new Hand("2S 5H 5D 2S JS");

            Assert.Greater(high, low);
        }

		[Test]
		public void StraightBeatsThreeOfAKind()
		{
			var high = new Hand("2H 3S 4S 5S 6S");
			var low = new Hand("2H 3S 7S 7C 7H");

			Assert.Greater(high, low);
		}

		[Test]
		public void NotAStraight()
		{
			var high = new Hand("2H 3S 3S 5S 6S");
			var low = new Hand("2H 3S 4S 5C 7H");

			Assert.Greater(high, low);
		}

		[Test]
		public void FlushBeatsStraight()
		{
			var high = new Hand("2H 3H 4H 5H 7H");
			var low = new Hand("10H JS QS KC AH");

			Assert.Greater(high, low);
		}


    	[Test]
        public void FullHouseBeatsFlush()
        {
            var whiteHand = new Hand("2H 4S 4C 2D 4H");
			var blackHand = new Hand("2H 3H 4H 5H 7H");

            Assert.Greater(whiteHand, blackHand, "White should be the winner");
        }

		[Test]
		public void FourOfAKindBeatsFullHouse()
		{
			var low = new Hand("AH KS KC AD KH");
			var high = new Hand("2H 2C 2D 2S 5H");

			Assert.Greater(high, low, "White should be the winner"); 
		}

		[Test]
		public void StraightFlushBeatsFourOfAKind()
		{
			var high = new Hand("2H 3H 4H 5H 6H");
			var low = new Hand("AH AC AD AS KH");

			Assert.Greater(high, low, "White should be the winner"); 
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

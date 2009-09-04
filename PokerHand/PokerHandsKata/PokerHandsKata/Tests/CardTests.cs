using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PokerHandsKata
{
    [TestFixture]
    public class CardTests
    {
        //primarily just to define the enum values in the test
        [TestCase(CardValue.Two, CardSuit.Clubs, CardValue.Two, CardSuit.Clubs, 0)]
        [TestCase(CardValue.Two, CardSuit.Clubs, CardValue.Three, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Three, CardSuit.Clubs, CardValue.Four, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Four, CardSuit.Clubs, CardValue.Five, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Five, CardSuit.Clubs, CardValue.Six, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Six, CardSuit.Clubs, CardValue.Seven, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Seven, CardSuit.Clubs, CardValue.Eight, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Eight, CardSuit.Clubs, CardValue.Nine, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Nine, CardSuit.Clubs, CardValue.Ten, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Ten, CardSuit.Clubs, CardValue.Jack, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Jack, CardSuit.Clubs, CardValue.Queen, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Queen, CardSuit.Clubs, CardValue.King, CardSuit.Clubs, -1)]
        [TestCase(CardValue.King, CardSuit.Clubs, CardValue.Ace, CardSuit.Clubs, -1)]
        [TestCase(CardValue.Ace, CardSuit.Clubs, CardValue.Ace, CardSuit.Clubs, 0)]
        public void CardValueTest(CardValue value1, CardSuit suit1, CardValue value2, CardSuit suit2, int expected)
        {
            Card card1 = new Card(value1, suit1);
            Card card2 = new Card(value2, suit2);

            Assert.AreEqual(expected, card1.CompareTo(card2));
            
        }

        [Test]
        public void Same_Card_Of_Different_Suits_Should_Be_Equal()
        {
            Card card1 = new Card(CardValue.Two, CardSuit.Clubs);
            Card card2 = new Card(CardValue.Two, CardSuit.Spades);

            Assert.AreEqual(0, card1.CompareTo(card2));
        }

        

    }
}

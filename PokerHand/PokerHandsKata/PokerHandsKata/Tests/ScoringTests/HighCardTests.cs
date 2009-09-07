using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class HighCardTests
    {
        [Test]
        public void TestLess()
        {
            HighCardScore two = new HighCardScore(CardValue.Two);
            HighCardScore three = new HighCardScore(CardValue.Three);

            Assert.AreEqual(-1, two.CompareTo(three));
        }

        [Test]
        public void TestGreater()
        {
            HighCardScore two = new HighCardScore(CardValue.Two);
            HighCardScore three = new HighCardScore(CardValue.Three);

            Assert.AreEqual(1, three.CompareTo(two));
        }

        [Test]
        public void TestTie()
        {
            HighCardScore two = new HighCardScore(CardValue.Two);
            HighCardScore anotherTwo = new HighCardScore(CardValue.Two);

            Assert.AreEqual(0, two.CompareTo(anotherTwo));
        }

    }
}

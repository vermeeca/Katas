using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PokerHandsKata.Tests
{
    [TestFixture]
    public class DeckTests
    {
        [TestCase("2H", CardValue.Two, CardSuit.Hearts)]
        public void MapStringToCard(string value, CardValue expectedValue, CardSuit expectedSuit )
        {
            Assert.Fail("Do");
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PokerHandsKata.Tests
{
    [TestFixture]
    public class SuitParserTests
    {
        [TestCase("H", CardSuit.Hearts)]
        [TestCase("D", CardSuit.Diamonds)]
        [TestCase("S", CardSuit.Spades)]
        [TestCase("C", CardSuit.Clubs)]
        public void TestParse(string value, CardSuit expected)
        {
            SuitParser p = new SuitParser();
            Assert.AreEqual(expected, p.Parse(value));
        }
    }
}

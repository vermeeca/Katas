using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PokerHandsKata.Tests
{
    [TestFixture]
    public class ValueParserTests
    {
        [TestCase("2", CardValue.Two)]
        [TestCase("3", CardValue.Three)]
        [TestCase("4", CardValue.Four)]
        [TestCase("5", CardValue.Five)]
        [TestCase("6", CardValue.Six)]
        [TestCase("7", CardValue.Seven)]
        [TestCase("8", CardValue.Eight)]
        [TestCase("9", CardValue.Nine)]
        [TestCase("10", CardValue.Ten)]
        [TestCase("J", CardValue.Jack)]
        [TestCase("Q", CardValue.Queen)]
        [TestCase("K", CardValue.King)]
        [TestCase("A", CardValue.Ace)]
        public void ParseValue(string value, CardValue expected)
        {
            ValueParser p = new ValueParser();
            Assert.AreEqual(expected, p.Parse(value) );
        }
    }
}

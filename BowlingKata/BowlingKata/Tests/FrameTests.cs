using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class FrameTests
    {
        [TestCase("9-", 9, 0)]
        [TestCase("--", 0, 0)]
        [TestCase("X-", 10, 0)]
        [TestCase("5/", 5, 5)]
        public void TestFrameParsing(string balls, int one, int two)
        {
            var frame = new Frame(balls);
            Assert.AreEqual(one, frame.BallOne);
            Assert.AreEqual(two, frame.BallTwo);
        }
   

        [TestCase("9-", false)]
        [TestCase("9/", true)]
        [TestCase("X-", false)]
        public void TestSpare(string balls, bool expected)
        {
            Frame frame = new Frame(balls);
            Assert.AreEqual(expected, frame.IsSpare);
        }

        [TestCase("9-", false)]
        [TestCase("9/", false)]
        [TestCase("X-", true)]
        public void TsetStrike(string balls, bool expected)
        {
            Frame frame = new Frame(balls);
            Assert.AreEqual(expected, frame.IsStrike);
        }
    }
}

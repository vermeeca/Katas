using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class ScoreTests
    {
        [Test]
        public void OnePin()
        {
            var score = new Score();
            score.AddFrame(new Frame("1-"));
            score.AddFrame(new Frame("1-"));
            Assert.AreEqual(2, score.GetScore());
        }

        [Test]
        public void Spare()
        {
            var score = new Score();
            score.AddFrame(new Frame("1-"));
            score.AddFrame(new Frame("1/"));
            Assert.AreEqual(11, score.GetScore());
        }

        [Test]
        public void SpareShouldCarryOverNextBall()
        {
            var score = new Score();
            score.AddFrame(new Frame("1/"));
            score.AddFrame(new Frame("1-"));
            Assert.AreEqual(12, score.GetScore());
        }

        [Test]
        public void SpareShouldCarryOverOnlyNextBall()
        {
            var score = new Score();
            score.AddFrame(new Frame("1/"));
            score.AddFrame(new Frame("-1"));
            Assert.AreEqual(11, score.GetScore());
        }

        [Test]
        public void StrikeShouldCarryOverNextTwoBalls()
        {
            var score = new Score();
            score.AddFrame(new Frame("X-"));
            score.AddFrame(new Frame("11"));
            Assert.AreEqual(14, score.GetScore());
        }

        [Test]
        public void TestTwoStrikes()
        {
            var score = new Score();
            score.AddFrame(new Frame("X-"));
            score.AddFrame(new Frame("X-"));
            score.AddFrame(new Frame("1-"));
            Assert.AreEqual(34, score.GetScore());
        }


        [Test]
        public void TestTurkey()
        {
            var score = new Score();
            score.AddFrame(new Frame("X-"));
            score.AddFrame(new Frame("X-"));
            score.AddFrame(new Frame("X-"));
            score.AddFrame(new Frame("1-"));
            Assert.AreEqual(63, score.GetScore());
        }
    }
}

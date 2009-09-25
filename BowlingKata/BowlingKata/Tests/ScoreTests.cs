using System;
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
            Array.ForEach<char>("1-1-".ToCharArray(), score.RollBall);

            Assert.AreEqual(2, score.GetScore());
        }

        [Test]
        public void Spare()
        {
            var score = new Score();
            Array.ForEach<char>("1-1/".ToCharArray(), score.RollBall);
            Assert.AreEqual(11, score.GetScore());
        }

        [Test]
        public void SpareShouldCarryOverNextBall()
        {
            var score = new Score();

            Array.ForEach<char>("1/1-".ToCharArray(), score.RollBall);

            Assert.AreEqual(12, score.GetScore());
        }

        [Test]
        public void SpareShouldCarryOverOnlyNextBall()
        {
            var score = new Score();
            
            Array.ForEach<char>("1/-1".ToCharArray(), score.RollBall);
            Assert.AreEqual(11, score.GetScore());
        }

        [Test]
        public void StrikeShouldCarryOverNextTwoBalls()
        {
            var score = new Score();
            Array.ForEach<char>("X-11".ToCharArray(), score.RollBall);
            Assert.AreEqual(14, score.GetScore());
        }

        [Test]
        public void TestTwoStrikes()
        {
            var score = new Score();

            Array.ForEach<char>("X-X-1-".ToCharArray(), score.RollBall);
            Assert.AreEqual(34, score.GetScore());
        }


        [Test]
        public void TestTurkey()
        {
            var score = new Score();
            Array.ForEach<char>("X-X-X-1-".ToCharArray(), score.RollBall);
            Assert.AreEqual(63, score.GetScore());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BowlingKata.Tests
{
	[TestFixture]
	public class GameTests
	{
	    private BowlingGame bg;

	    [SetUp]
	    public void Setup()
        {
            bg = new BowlingGame();
        }

	    [TestCase("9-9-9-9-9-9-9-9-9-9-", 90)]
		[TestCase("X-X-X-X-X-X-X-X-X-X-XX", 300)]
		[TestCase("5/5/5/5/5/5/5/5/5/5/5", 150)]
		public void TestGameScore(string game, int expectedScore)
		{
		    Array.ForEach<char>(game.ToCharArray(), bg.Roll);
			Assert.AreEqual(expectedScore, bg.GetScore());
		}

        [Test]
        public void single_roll_should_be_number()
        {
            bg.Roll('1');
            Assert.AreEqual(1, bg.GetScore());
        }

        [Test]
        public void gutterball_should_be_zero()
        {
            bg.Roll('-');
            Assert.AreEqual(0, bg.GetScore());
        }

        [Test]
        public void two_rolls_should_add_up()
        {
            bg.Roll('1');
            bg.Roll('1');
            Assert.AreEqual(2, bg.GetScore());
        }

        [Test]
        public void test_just_spare()
        {
            bg.Roll('1');
            bg.Roll('/');
            Assert.AreEqual(10, bg.GetScore());
        }
	}
}

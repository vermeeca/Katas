using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BowlingKata.Tests
{
	[TestFixture]
	public class GameTests
	{
		[TestCase("9-9-9-9-9-9-9-9-9-9-", 90)]
		[TestCase("X-X-X-X-X-X-X-X-X-X-XX", 300)]
		[TestCase("5/5/5/5/5/5/5/5/5/5/5", 150)]
		public void TestGameScore(string game, int expectedScore)
		{
			int score = new BowlingGame(game).CalculateScore();
			Assert.AreEqual(expectedScore, score);
		}
	}
}

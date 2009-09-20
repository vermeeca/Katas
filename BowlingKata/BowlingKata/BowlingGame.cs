using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
	public class BowlingGame
	{
		private char[] _balls;
		public BowlingGame(string game)
		{
			_balls = game.ToCharArray();
		}

		public int CalculateScore()
		{
			int dummy = 0;
			return (from b in _balls
			       where Int32.TryParse(b.ToString(), out dummy)
			       select int.Parse(b.ToString())).Sum();

		}
	}
}
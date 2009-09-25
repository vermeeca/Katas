using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BowlingKata
{
	public class BowlingGame
	{
	    private List<char> rolled;

		public BowlingGame()
		{
		    rolled = new List<char>();
		}

		public int GetScore()
		{
		    return rolled.Sum(c => ScoreRoll(c));
		}

        public int ScoreRoll(char ball)
        {
            return ball == '-' ? 0 : Convert.ToInt32(ball.ToString());
        }



	    public void Roll(char ball)
	    {
	        rolled.Add(ball);
	    }
	}
}
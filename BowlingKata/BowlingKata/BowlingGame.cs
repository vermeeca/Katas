using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BowlingKata
{
	public class BowlingGame
	{
	    private Scorer _scorer = new Scorer();
		public BowlingGame()
		{
			
		}

		public int GetScore()
		{
            return _scorer.CurrentScore;
		}

	   

	    public void Roll(char ball)
	    {
	        _scorer.Roll(ball);
	    }
	}
}
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
			return CalculateScoreInternal(Frame.BeginningFrame, _balls);
		}

		private int CalculateScoreInternal(Frame lastFrame, char[] remainingBalls)
		{

			if(lastFrame.Number == 9)
			{
				return new Frame(lastFrame, remainingBalls).Score;
			}
			else
			{
				return lastFrame.Score + CalculateScoreInternal(new Frame(lastFrame, remainingBalls.Take(2).ToArray()),
				                              remainingBalls.Take(remainingBalls.Length - 2).ToArray());
			}
			

		}
	}
}
using System;
using System.Linq;

namespace BowlingKata
{
	public class Frame
	{

		public Frame()
		{
		    
		}

	    public void Roll(char ball)
	    {
	        Evaluate(ball);
	    }

	    public int? BallOne { get; set; }

	    public int? BallTwo { get; set; }

        public bool IsSpare { get { return BallOne < 10 && BallOne + BallTwo == 10; } }

	    public bool IsStrike { get{ return BallOne == 10;} }

        public bool IsFull()
        {
            return BallOne != null && BallTwo != null;
        }

	    private void Evaluate(char ball)
        {
            if (BallOne == null)
            {
                BallOne = MatchesStrike(ball) ? 10 : EvaluateBall(ball);
            }
            else
            {
                BallTwo = MatchesSpare(ball) ? 10 - BallOne : EvaluateBall(ball);
            }
        }

	    private int EvaluateBall(char ball)
	    {
	        return ball == '-' ? 0 : int.Parse(ball.ToString());
	    }

	    private bool MatchesSpare(char ball)
	    {
	        return ball == '/';
	    }

	    private bool MatchesStrike(char ball)
	    {
	        return ball == 'X';
	    }


	}
}
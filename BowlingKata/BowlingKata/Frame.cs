using System;
using System.Linq;

namespace BowlingKata
{
	public class Frame
	{

		public Frame(char[] balls)
		{
		    EvaluatePins(balls);
		}

	    public Frame(string balls) : this(balls.ToCharArray())
	    {
	        
	    }

	    public int BallOne { get; set; }

	    public int BallTwo { get; set; }

        public bool IsSpare { get { return BallOne < 10 && BallOne + BallTwo == 10; } }

	    public bool IsStrike { get{ return BallOne == 10;} }

        private void EvaluatePins(char[] balls)
        {
            char ballOne = balls[0];
            char ballTwo = balls[1];
            BallOne = MatchesStrike(ballOne) ? 10 : EvaluateBall(ballOne);
            BallTwo = MatchesSpare(ballTwo) ? 10 - BallOne : EvaluateBall(ballTwo);
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

	    public int Number { get; set; }
	}
}
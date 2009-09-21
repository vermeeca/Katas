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
		    return ScoreFrames(_balls).Sum(f => f.Score);
		}

	    private List<Frame> ScoreFrames(char[] balls)
	    {
	        List<Frame> frames = new List<Frame>();
	        ScoreFramesInternal(frames, balls);
            return frames;
	    }

	    private void ScoreFramesInternal(List<Frame> frames, char[] remainingBalls)
		{
            //totally not working.  Start over, starting with the frame class
            //test it first this time, stupid

            //Frame lastFrame = frames[frames.Count - 1];
            //if(lastFrame.Number == 9)
            //{
            //    frames.Add(new Frame(lastFrame, remainingBalls));
            //}
            //else
            //{
            //    frames.Add(new Frame(lastFrame, remainingBalls.Take(2).ToArray()));
            //    ScoreFramesInternal(frames, remainingBalls.Take(remainingBalls.Length - 2).ToArray());
            //}
			

		}
	}
}
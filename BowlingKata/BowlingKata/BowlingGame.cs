using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BowlingKata
{
	public class BowlingGame
	{
	    private List<char> _allRolls = new List<char>();
	    private List<Frame> _allframes = new List<Frame>();
	    private List<Frame> _scoringFrames = new List<Frame>();
	    private Frame _lastFrame;
        
		public BowlingGame()
		{

		}

		public int GetScore()
		{
		    return _allframes.Sum(f => f.Score);
		}

        


	    public void Roll(char ball)
	    {
            if(_lastFrame == null || !_lastFrame.IsOpen)
            {
                Frame f = new Frame(_lastFrame == null ? 1 : _lastFrame.FrameNumber + 1);
                _scoringFrames.Add(f);
                _allframes.Add(f);
                _lastFrame = f;
            }

	        _scoringFrames.ForEach(f => f.Roll(ball));
            _scoringFrames.RemoveAll(f => !f.StillScoring);

	        _allRolls.Add(ball);

	    }
	}
}
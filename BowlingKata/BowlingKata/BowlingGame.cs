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
	    private List<Frame> _openFrames = new List<Frame>();
        
		public BowlingGame()
		{

		}

		public int GetScore()
		{
		    return _allframes.Sum(f => f.Score);
		}

        


	    public void Roll(char ball)
	    {
            if(_allRolls.Count % 2 == 0)
            {
                Frame f = new Frame();
                _openFrames.Add(f);
                _allframes.Add(f);
            }

	        _openFrames.ForEach(f => f.Roll(ball));
	        _openFrames.RemoveAll(f => !f.IsOpen);

	        _allRolls.Add(ball);

	    }
	}
}
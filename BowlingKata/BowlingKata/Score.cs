using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Score
    {

        private List<Frame> _frames = new List<Frame>();

        public void AddFrame(Frame frame)
        {
            _frames.Add(frame);
        }

        public int GetScore()
        {
            return (from f in _frames
                    select f.BallOne + f.BallTwo).Sum();
        }
    }
}
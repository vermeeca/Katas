using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Score
    {

        private List<Frame> _frames = new List<Frame>();

        public void RollBall(char ball)
        {
            Frame workingFrame = GetWorkingFrame();
            workingFrame.Roll(ball);
        }

        private Frame GetWorkingFrame()
        {
            return _frames.Count > 0 && !_frames.Last().IsFull() ? _frames.Last() : NewFrame();
        }

        private Frame NewFrame()
        {
            Frame frame = new Frame();
            _frames.Add(frame);
            return frame;
        }

        public int GetScore()
        {
            return (from f in _frames
                    select f.BallOne.Value + f.BallTwo.Value).Sum();
        }
    }
}
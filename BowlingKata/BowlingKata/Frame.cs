using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Frame
    {
        public int Score { get; private set; }
        private List<char> _rolls = new List<char>();
        private List<char> _extraRolls = new List<char>();

        private static readonly Dictionary<char, Func<Frame, int>> map;
        public bool StillScoring { get; private set; }
        private bool IsStrike{get;set;}
        private bool IsSpare{get;set;}

        public int FrameNumber { get; private set; }

        static Frame()
        {
            map = new Dictionary<char, Func<Frame, int>>
                      {
                          {'-', f => 0},
                          {'1', f => 1},
                          {'2', f => 2},
                          {'3', f => 3},
                          {'4', f => 4},
                          {'5', f => 5},
                          {'6', f => 6},
                          {'7', f => 7},
                          {'8', f => 8},
                          {'9', f => 9},
                          {'/', f => {
                                         f.IsSpare = true;
                                         return 10 - f.Score; }},
                          {'X', f => {
                                         f.IsStrike = true;
                                         return 10; }}
                      };
        }

        public Frame() : this(0)
        {
        }

        public Frame(int frameNumber)
        {
            FrameNumber = frameNumber;
            IsOpen = true;
            StillScoring = true;
        }

        /// <summary>
        /// Ugly ugly ugly
        /// </summary>
        /// <param name="c"></param>
        public void Roll(char c)
        {

            if(IsSpare)
            {
                StillScoring = false;
                Score += ScoreBall(c);
                IsOpen = FrameNumber < 10;
                return;
            }

            if(IsStrike)
            {
                IsOpen = FrameNumber == 10;
                if(_extraRolls.Count == 1)
                {
                    _extraRolls.Add(c);
                    StillScoring = false;
                    Score += _extraRolls.Sum(e => ScoreBall(e));
                }
                else
                {                   
                    _extraRolls.Add(c);
                }

                return;
            }

            if(_rolls.Count == 1)
            {
                Score += ScoreBall(c);
                IsOpen = FrameNumber == 10 ? IsSpare : false;
                StillScoring = IsSpare;
            }
            else
            {
                _rolls.Add(c);
                Score += ScoreBall(c);
                IsOpen = FrameNumber == 10 ? true : !IsStrike;
            }

            
        }

        public bool IsOpen { get; private set; }

        private int ScoreBall(char ball)
        {
            return map[ball](this);
        }


    }
}
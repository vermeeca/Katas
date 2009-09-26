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
        private bool IsStrike{get;set;}
        private bool IsSpare{get;set;}

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

        public Frame()
        {
            IsOpen = true;
        }

        public void Roll(char c)
        {
            if(IsSpare)
            {
                IsOpen = false;
                Score += ScoreBall(c);
                return;
            }

            if(IsStrike)
            {
                if(_extraRolls.Count == 1)
                {
                    _extraRolls.Add(c);
                    IsOpen = false;
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
                IsOpen = IsSpare;
            }
            else
            {
                _rolls.Add(c);
                Score += ScoreBall(c);
            }

        }

        public bool IsOpen { get; private set; }

        private int ScoreBall(char ball)
        {
            return map[ball](this);
        }


    }
}
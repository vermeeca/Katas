using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandsKata.HandEvaluation;
using PokerHandsKata.Scoring;

namespace PokerHandsKata
{
    public class Hand : IComparable
    {

        public List<Card> Cards { get; private set; }
    	private HandEvaluator _evaluator = new HandEvaluator();
        
        public Hand(string[] cards)
        {
            Cards = new List<Card>();
            var suitParser = new SuitParser();
            var valueParser = new ValueParser();

            


            foreach (var card in cards)
            {
                string suit = card.Substring(card.Length - 1);
                string value = card.Substring(0, card.Length - 1);

                Cards.Add(new Card(valueParser.Parse(value), suitParser.Parse(suit)));
            }
            
        }

        public Hand(string s) : this(s.Split(' '))
        {
            
        }


        public int CompareTo(object obj)
        {
            var other = obj as Hand;
            if(other != null)
            {
                return this.GetScore().CompareTo(other.GetScore());
            }

            return 1;
        }

        private IScore GetScore()
        {
        	return _evaluator.Score(this);
        }


    }
}
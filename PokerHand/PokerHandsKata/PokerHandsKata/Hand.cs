using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsKata
{
    public class Hand : IComparable
    {

        public List<Card> Cards { get; private set; }
        
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

            //sort, for ease of evaluation
            Cards.Sort();
            
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

        private int GetScore()
        {
            int baseValue = Enum.GetValues(typeof (CardValue)).Length;
            
            int score = 0;

            //bah.  come back later to this.
            //////find pairs
            ////var pairs = (from c in Cards
            ////            join c2 in Cards on c equals c2
            ////            select (int)c.Value*baseValue).ToList();

            //pairs.ForEach((p) => score += p);


            score += (int)this.Cards[Cards.Count - 1].Value;

            return score;
        }


    }
}
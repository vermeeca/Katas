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

        private long GetScore()
        {
            
            long score = 0;

            //bah.  come back later to this.
            //find pairs
            var pairs = (from c in Cards
                         join c2 in Cards on c.Value equals c2.Value
                         where Object.ReferenceEquals(c, c2) == false
                         select (int)c.Value.Score() * CardValue.Ace.Score()).Distinct().ToList();

            pairs.ForEach((p) => score += p * (pairs.Count * CardValue.Ace.Score()));


            //high card
            Cards.ForEach(c => score += (int)c.Value.Score());
               

            return score;
        }


    }
}
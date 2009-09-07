using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandsKata.Scoring;

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

        private IScore GetScore()
        {

            CompositeScore handScore = new CompositeScore();

            //pairs
            var pairs = (from c in Cards
                         join c2 in Cards on c.Value equals c2.Value
                         where object.ReferenceEquals(c, c2) == false
                         select c.Value).Distinct().ToList();

            if (pairs.Count == 1)
            {
                pairs.ForEach(p => handScore.Add(new PairScore(p)));
            }
            else if(pairs.Count == 2)
            {
                handScore.Add(new TwoPairScore(pairs[0], pairs[1]));
            }

            


            //high card
            Cards.ForEach(c => handScore.Add(new HighCardScore(c.Value)));

            return handScore;
        }


    }
}
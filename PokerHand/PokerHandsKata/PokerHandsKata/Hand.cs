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

        //okay, I'm at the point where this is definitely going to need refactored
        private IScore GetScore()
        {
			
            CompositeScore handScore = new CompositeScore();

        	var sets = (from c in Cards
        	           group c by c.Value
        	           into g orderby g.Key
        	           	select new {Value=g.Key,Count=g.Count()}).ToList();

        	var suits = from c in Cards
        	            group c by c.Suit
        	            into g 
        	            	select new {Suit = g.Key, Count = g.Count()};

			foreach(var set in sets)
			{
				switch(set.Count)
				{
					case 4:
						handScore.Add(new FourOfAKindScore(set.Value));
						break;
					case 3:
						var pairAlso = sets.FindLast((s) => s.Count == 2);
						if (pairAlso == null)
						{
							handScore.Add(new ThreeOfAKindScore(set.Value));
						}
						else
						{
							handScore.Add(new FullHouseScore(set.Value, pairAlso.Value));
						}
						break;
					case 2:
						var otherPair = sets.FindLast(s => s.Count == 2 && !object.ReferenceEquals(set, s));
						if(otherPair == null)
						{
							handScore.Add(new PairScore(set.Value));
						}
						else
						{
							handScore.Add(new TwoPairScore(set.Value, otherPair.Value));
						}
						break;
					case 1:
						handScore.Add(new HighCardScore(set.Value));
						break;

				}
			}

        	return handScore;



        }


    }
}
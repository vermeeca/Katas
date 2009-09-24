using System;
using System.Collections.Generic;
using System.Linq;

namespace Greed
{
	
	public class ScoreCalculator
	{
		private static readonly
			List<Func<IEnumerable<NumberGroup>, int>> _map = new List<Func<IEnumerable<NumberGroup>, int>>();
 
		static ScoreCalculator()
		{
			_map = new List<Func<IEnumerable<NumberGroup>, int>>
			       	{
						//sets of 1s
			       		grouped => SumBy(n => (n.Number == 1 && n.Count >= 3), n => n.Number, 1000, grouped),
						//sets of non-1s
			       		grouped => SumBy(n => (n.Number != 1 && n.Count >= 3), n => n.Number, 100, grouped),
						//individual 1s
			       		grouped => SumBy(n => (n.Number == 1 && n.Count != 3), n => n.Count%3, 100, grouped),
						//individual 5s
			       		grouped => SumBy(n => (n.Number == 5 && n.Count != 3), n => n.Count%3, 50, grouped)
			       	};

		}


		public int Score(params int[] rolls)
		{
			int score = 0;
			var grouped = (from r in rolls
			               group r by r into g
						   select new NumberGroup{Number=g.Key, Count=g.Count() });
			 
			return (from m in _map
			        select m(grouped)).Sum();

		}

		private static int SumBy(Func<NumberGroup, bool> condition, Func<NumberGroup, int> scorer, int multipler, IEnumerable<NumberGroup> numGroup)
		{
			return (from g in numGroup
					where condition(g)
					select scorer(g) * multipler).Sum();
		}

	



	}
}
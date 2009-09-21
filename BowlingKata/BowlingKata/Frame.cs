using System;
using System.Linq;

namespace BowlingKata
{
	public class Frame
	{
		public static Frame BeginningFrame;

		public Frame(Frame previousFrame, char[] balls)
		{
		    Number = CalculateCurrentFramePins(balls);
			if(previousFrame.IsSpare)
			{

			}
		}

	    protected bool IsSpare { get; set; }

       
	    private int CalculateCurrentFramePins(char[] balls)
        {
            if (Array.Exists<char>(balls, (b) => b == '/' || b == 'X'))
            {
                return 10;
            }
            int dummy = 0;
            return (from b in balls
                    where int.TryParse(b.ToString(), out dummy)
                    select Convert.ToInt32(b.ToString())).Sum();
        }

	    public int Score{get;set;}

		public int Number { get; set; }
	}
}
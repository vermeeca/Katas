using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata._2009_12_02
{
    internal class StringCalculator
    {
        public int Sum(string val)
        {
            string[] vals = Parse(val);
            List<int> invalidNumbers = new List<int>();
            List<int> nums = vals.ToList().ConvertAll<int>(s =>
                                                          {
                                                              int num = 0;
                                                              Int32.TryParse(s, out num);
                                                              if(num < 0)
                                                              {
                                                                  invalidNumbers.Add(num);
                                                              }
                                                              return num;
                                                          });

            if(invalidNumbers.Count > 0)
            {
                throw new NegativeNumbersNotSupportedException(invalidNumbers);
            }
            return nums.Sum();
        }

        private string[] Parse(string val)
        {
            char[] delimiters = new char[] {',', '\n'};
            
            if(HasCustomDelimiter(val))
            {
                delimiters = DetermineCustomDelimiters(val);
                val = val.Substring(val.IndexOf('\n') + 1);

            }

            return val.Split(delimiters);
        }

        private bool HasCustomDelimiter(string val)
        {
            return val.StartsWith("//", StringComparison.CurrentCultureIgnoreCase);
        }

        private char[] DetermineCustomDelimiters(string val)
        {
            return val.Substring(val.IndexOf("//") + 2, 1).ToCharArray();
        }
    }
}
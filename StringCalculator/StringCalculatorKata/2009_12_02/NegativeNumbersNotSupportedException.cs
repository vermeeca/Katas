using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorKata._2009_12_02
{
    public class NegativeNumbersNotSupportedException : Exception
    {
        public List<int> Numbers { get; set; }

        public NegativeNumbersNotSupportedException(IEnumerable<int> numbers)
        {
            Numbers = numbers.ToList();
        }

        public override string Message
        {
            get
            {
                return string.Format(string.Format("negatives not allowed - {0}", FormatNumbers()));
            }
        }

        private string FormatNumbers()
        {
            var sb = new StringBuilder();
            Numbers.ForEach(i=>sb.AppendFormat("{0},", i));

            return sb.ToString().Remove(sb.ToString().Length - 1);
        }
    }
}
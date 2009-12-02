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
            string[] vals = val.Split(',');
            List<int> nums = vals.ToList().ConvertAll<int>(s =>
                                                          {
                                                              int num = 0;
                                                              Int32.TryParse(s, out num);
                                                              return num;
                                                          });
            return nums.Sum();
        }
    }
}
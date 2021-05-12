using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Examples
{
    public class FizzBuzzDemo
    {
        public string FizzBuzz(int i)
        {
            var mod3 = i % 3;
            var mod5 = i % 5;
            if (mod3 == 0 && mod5 == 0)
            {
                return "FizzBuzz";
            }
            else if (mod3 == 0)
            {
                return "Fizz";
            }
            else if (mod5 == 0)
            {
                return "Buzz";
            }
            return "" + i;
        }
    }
}
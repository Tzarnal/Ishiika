using System;
using Serilog;
using Ishiika;
using Ishiika.Library;
using System.Linq;
using System.Collections.Generic;

namespace Problems1_25
{
    public class Problem004 : IIshiikaProblem
    {
        public string ProblemName => "Largest palindrome product";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 4;

        public void Solve()
        {
            //FindPalindromeProduct(10, 99);
            FindPalindromeProduct(100, 999);
        }

        public void FindPalindromeProduct(int bottomRange, int topRange)
        {
            Dictionary<int, (int leftSide, int rightSide)> awnsers = new();

            //Assuming that the palindrome will be found in the top 20% of the number range, avoiding a lot of busywork for nothing.
            bottomRange = topRange - (topRange / 5);

            for (int leftSide = bottomRange; leftSide <= topRange; leftSide++)
            {
                for (int rightSide = bottomRange; rightSide <= topRange; rightSide++)
                {
                    //Just store all the palindromes we find
                    var product = leftSide * rightSide;
                    if (IsPalindrome(product))
                    {
                        awnsers[product] = (leftSide, rightSide);
                    }
                }
            }

            //Grab the largest palindrome
            var finalAwnser = awnsers.OrderByDescending(a => a.Key).First();

            Log.Information("Largest palindrome is {awnser} made from {leftSide} and {rightSide}",
            finalAwnser.Key, finalAwnser.Value.leftSide, finalAwnser.Value.rightSide);
        }

        private static bool IsPalindrome(int number) => number.ToString() == number.ToString().Reverse();
    }
}
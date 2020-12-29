using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem005 : IIshiikaProblem
    {
        public string ProblemName => "Smallest multiple";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 5;

        public void Solve()
        {
            //SmallestDivisbleByRangeNaive(1, 10);
            //SmallestDivisbleByRange(1, 10);

            //SmallestDivisbleByRangeNaive(1, 20); //232792560
            SmallestDivisbleByRange(1, 20);
        }

        public static void SmallestDivisbleByRange(int BottomRange, int TopRange)
        {
            var range = Enumerable.Range(BottomRange, TopRange - BottomRange + 1).Reverse().ToList();

            //Everything past the first half of the range actually tests against a multiple in the range so discard those.
            var limitedRange = range.Take(range.Count / 2);

            //No Need to start at 0, smallest number cannot be smaller than the largest divisor
            int number = TopRange;

            //Check any number untill
            while (number < int.MaxValue)
            {
                //All numbers in the range will divide it without remainder
                if (range.All(r => number % r == 0))
                {
                    Log.Information("Found {number}.", number);
                    return;
                }

                //Can't find a diviser of a number by incrementing by less than that number
                number += TopRange;
            }

            Log.Error("Could not find an awnser.");
        }

        public static void SmallestDivisbleByRangeNaive(int BottomRange, int TopRange)
        {
            var range = Enumerable.Range(BottomRange, TopRange - BottomRange + 1);

            int number = 1;

            //Check any number untill
            while (number < int.MaxValue)
            {
                //All numbers in the range will divide it without remainder
                if (range.All(r => number % r == 0))
                {
                    Log.Information("Found {number}.", number);
                    return;
                }

                number++;
            }

            Log.Error("Could not find an awnser.");
        }
    }
}
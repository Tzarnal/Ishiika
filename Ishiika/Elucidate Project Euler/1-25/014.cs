using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem014 : IIshiikaProblem
    {
        public string ProblemName => "Longest Collatz sequence";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 14;

        public void Solve()
        {
            var range = Enumerable.Range(1, 999_999);

            long longestChain = 0;

            foreach (var number in range)
            {
                longestChain = Math.Max(CollatzSequence(number), longestChain);
            }

            var startNumber = DP.First(d => d.Value == longestChain).Key;

            Log.Information("Longest chains was {longestChain} for starting number {startNumber}",
                longestChain, startNumber);
        }

        private Dictionary<long, long> DP = new();

        private long CollatzSequence(long Number)
        {
            if (Number == 1)
            {
                return 1;
            }

            if (DP.ContainsKey(Number))
            {
                return DP[Number];
            }

            long startNumber = Number;
            long sequenceLength = 1;

            while (Number != 1)
            {
                if (DP.ContainsKey(Number))
                {
                    sequenceLength += DP[Number];
                    break;
                }

                if (Number % 2 == 0)
                {
                    Number /= 2;
                }
                else
                {
                    Number = (Number * 3) + 1;
                }

                sequenceLength++;
            }

            DP[startNumber] = sequenceLength;

            return sequenceLength;
        }
    }
}
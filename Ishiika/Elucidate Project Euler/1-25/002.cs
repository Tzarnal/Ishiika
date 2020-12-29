using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using RegExtract;
using Serilog;
using Ishiika;

namespace Problem_002
{
    internal class Problem_002 : IIshiikaProblem
    {
        public string ProblemName => "Even Fibonacci numbers";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 2;

        public void Solve()
        {
            var lastNumber = 0;
            var currentNumber = 1;
            long runningTotal = 0;

            while (true)
            {
                var storage = currentNumber;

                currentNumber += lastNumber;
                lastNumber = storage;

                if (currentNumber > 4_000_000)
                    break;

                if (currentNumber % 2 == 0)
                    runningTotal += currentNumber;
            }

            Log.Information("Sum of all even fibonacci numbers to 4 million is {runningTotal}", runningTotal);
        }
    }
}
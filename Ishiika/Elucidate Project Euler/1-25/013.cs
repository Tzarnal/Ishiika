using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;
using System.IO;
using System.Numerics;

namespace Problems1_25
{
    public class Problem013 : IIshiikaProblem
    {
        public string ProblemName => "Large sum";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";

        public int ProblemID => 13;

        public void Solve()
        {
            BigInteger sum = 0;

            foreach (var number in ParseInput())
            {
                sum += number;
            }

            var value = string.Join("", sum.ToString().Take(10));

            Log.Information("First 10 digits of sum is {v}", value);
        }

        private List<BigInteger> ParseInput()
        {
            var inputLines = File.ReadAllLines(@"1-25/013.input.txt");

            return inputLines.Select(l => BigInteger.Parse(l)).ToList();
        }
    }
}
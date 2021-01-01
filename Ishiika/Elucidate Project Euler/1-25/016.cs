using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;
using System.Numerics;

namespace Problems1_25
{
    public class Problem016 : IIshiikaProblem
    {
        public string ProblemName => "Power digit sum";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 16;

        public void Solve()
        {
            var result = BigInteger.Pow(2, 1000).ToString().ToCharArray().Select(c => int.Parse(c.ToString())).Sum();

            Log.Information("The the sum of all the digits of 2^1000 is {result}.", result);
        }
    }
}
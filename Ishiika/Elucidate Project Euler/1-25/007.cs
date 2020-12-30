using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem007 : IIshiikaProblem
    {
        public string ProblemName => "10001st prime";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 7;

        public void Solve()
        {
            //NthPrime(6);
            NthPrime(10001);
        }

        public void NthPrime(int n)
        {
            var prime = IshiikaMath.GeneratePrimesTrialDivision(int.MaxValue).Skip(n - 1).Take(1).First();

            Log.Information("The {n}th prime is {prime}", n, prime);
        }
    }
}
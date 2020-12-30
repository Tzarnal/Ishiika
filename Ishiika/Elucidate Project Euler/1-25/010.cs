using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem010 : IIshiikaProblem
    {
        public string ProblemName => "Summation of primes";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 10;

        public void Solve()
        {
            SumOfPrimes(2_000_000);
        }

        private void SumOfPrimes(int upperLimit)
        {
            var primes = IshiikaMath.GeneratePrimes(upperLimit);
            long sum = 0;

            foreach (var number in primes)
            {
                sum += number;
            }

            Log.Information("The sum of the first {upperLimit} primes is {sum}", upperLimit, sum);
        }
    }
}
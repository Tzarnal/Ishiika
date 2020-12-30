using System;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    internal class Problem003 : IIshiikaProblem
    {
        public string ProblemName => "Largest prime factor";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 3;

        public void Solve()
        {
            //FindLargestPrimeFactor(13195);
            FindLargestPrimeFactor(600851475143);
        }

        public void FindLargestPrimeFactor(long target)
        {
            long awnser = 0;

            //Due to the nature of prime factors our prime factor will not exceed the square roor
            //of the number we are trying to find a prime factors for.
            var sqrtTarget = (int)Math.Sqrt(target);

            //Go through all the primes up tot the square root of the target and check if its a factor
            foreach (var prime in IshiikaMath.GeneratePrimes(sqrtTarget))
            {
                if (target % prime == 0)
                {
                    awnser = prime;
                }
            }

            Log.Information("Largest prime factor for {input} is {awnser}", target, awnser);
        }
    }
}
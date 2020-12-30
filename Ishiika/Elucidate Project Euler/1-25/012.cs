using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem012 : IIshiikaProblem
    {
        public string ProblemName => "Highly divisible triangular number";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 12;

        public void Solve()
        {
            const int divisorRequirement = 500;
            var SomePrimes = IshiikaMath.GeneratePrimes(100_000).ToArray();

            foreach (var triangle in TriangleNumbers(int.MaxValue))
            {
                var factorcountP = PrimeFactorCount(triangle, SomePrimes);

                if (factorcountP > divisorRequirement)
                {
                    Log.Information("First triangle number with over {requirement} divisors is {triangle}",
                        divisorRequirement, triangle);
                    return;
                }
            }

            Log.Information("A solution can be found.");
        }

        public static IEnumerable<int> TriangleNumbers(int UpperBound = int.MaxValue)
        {
            int triangle = 1;
            int i = 1;
            while (i < UpperBound)
            {
                yield return triangle;

                i++;
                triangle += i;
            }
        }

        private int FactorCountNaive(int Number)
        {
            var factors = 0;
            var numberSqrt = (int)Math.Sqrt(Number);

            for (int i = 1; i < numberSqrt; i++)
            {
                if (Number % i == 0)
                {
                    factors += 2;
                }
            }

            return factors;
        }

        private int PrimeFactorCount(int number, long[] primelist)
        {
            int factors = 1;
            int exponent;
            long remaining = number;

            for (int i = 0; i < primelist.Length; i++)
            {
                if (primelist[i] * primelist[i] > number)
                {
                    return factors * 2;
                }

                exponent = 1;
                while (remaining % primelist[i] == 0)
                {
                    exponent++;
                    remaining /= primelist[i];
                }

                factors *= exponent;

                //If there is no remainder, return the count
                if (remaining == 1)
                {
                    return factors;
                }
            }

            return factors;
        }
    }
}
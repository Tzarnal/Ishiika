using System.Linq;
using Serilog;
using Ishiika;

namespace Problem_001
{
    internal class Problem_001 : IIshiikaProblem
    {
        public string ProblemName => "Multiples of 3 and 5";
        public string ProblemURL => "https://projecteuler.net/problem=1";
        public int ProblemID => 1;

        public void Solve()
        {
            var rangerLowerBound = 0;
            var rangerUpperBound = 1000;
            var firstrequirement = 3;
            var secondRequirement = 5;

            var awnser = Enumerable.Range(rangerLowerBound, rangerUpperBound)
                    .Where(n => n % firstrequirement == 0 || n % secondRequirement == 0)
                    .Sum(n => n);

            Log.Information("The sum of all numbers from {rangeLowerBound} to {rangerUpperBound} divisable by {firstrequirement} or {secondRequirement} is {awnser}",
                rangerLowerBound, rangerUpperBound, firstrequirement, secondRequirement, awnser);
        }
    }
}
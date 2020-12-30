using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem006 : IIshiikaProblem
    {
        public string ProblemName => "Sum square difference";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 6;

        public void Solve()
        {
            //SumNaturalSquareDifference(10);
            SumNaturalSquareDifference(100);
        }

        public void SumNaturalSquareDifference(int upperLimit)
        {
            var numbers = Enumerable.Range(1, upperLimit);

            var sumofNumbers = numbers.Sum();
            var squareOfSumOfNumbers = sumofNumbers * sumofNumbers;

            var sumofSquares = numbers.Select(n => n * n).Sum();

            var difference = squareOfSumOfNumbers - sumofSquares;

            Log.Information("Difference between the first {upperLimit} Summed^2 and Squared and Summed: {squareOfSumOfNumbers} - {sumofSquares} = {difference}"
                , upperLimit, squareOfSumOfNumbers, sumofSquares, difference);
        }
    }
}
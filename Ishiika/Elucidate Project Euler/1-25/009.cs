using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem009 : IIshiikaProblem
    {
        public string ProblemName => "Special Pythagorean triplet";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 9;

        public void Solve()
        {
            var total = 1000;

            for (var a = 1; a < total; a++)
            {
                for (var b = 1; b < total; b++)
                {
                    //Because we were limited to 1000 c must be the diference between our known values of a and b and 1000;
                    var c = total - (a + b);

                    var aSquared = a * a;
                    var bSquared = b * b;
                    var cSquared = c * c;

                    if (aSquared + bSquared == cSquared)
                    {
                        Log.Information("The pythagorean triplet that sums to {total} is {a}, {b} and {c}. The product is {product}",
                            total, a, b, c, a * b * c);
                        return;
                    }
                }
            }
        }
    }
}
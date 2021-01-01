using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;
using System.Numerics;

namespace Problems1_25
{
    public class Problem000 : IIshiikaProblem
    {
        public string ProblemName => "Template Problem";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 0;

        public void Solve()
        {
            Log.Information("A solution can be found.");
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problem0_0
{
    public class TemplateProblem : IIshiikaProblem
    {
        public string ProblemName => "Template Problem";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 1;

        public void Solve()
        {
            Log.Information("A solution can be found.");
        }
    }
}
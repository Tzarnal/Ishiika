using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using RegExtract;
using Serilog;
using Ishiika;

namespace Problem_000
{
    class TemplateProblem : IIshiikaProblem
    {
        public string ProblemName => "Template Problem";
        public string ProblemURL => "https://template.website/problem";
        public int ProblemID => 1;

        public void Solve()
        {
            Log.Information("A solution can be found.");
        }
    }
}
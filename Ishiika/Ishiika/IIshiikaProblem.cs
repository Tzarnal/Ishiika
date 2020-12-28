using System;
using System.Collections.Generic;
using System.Text;

namespace Ishiika
{
    interface IIshiikaProblem
    {
        public void Solve();

        public string ProblemName { get; }
        public string ProblemURL { get; }

        public int ProblemID { get; }
    }
}
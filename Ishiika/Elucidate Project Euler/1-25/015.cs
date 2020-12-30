using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem015 : IIshiikaProblem
    {
        public string ProblemName => "Lattice paths";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 15;

        public void Solve()
        {
            RoutesThroughGrid(2);
            RoutesThroughGrid(5);
            RoutesThroughGrid(20);
        }

        public void RoutesThroughGrid(int GridSize)
        {
            //Since we are counting from border to border instead of internal space we need to increase our size by one.
            var grid = new long[GridSize + 1, GridSize + 1];

            //Since our only options are Down and Right we know the amount of available paths from the Right and Bottom eges
            //Its 1 since we canot take any other choices anymore
            for (int i = 0; i < GridSize; i++)
            {
                grid[i, GridSize] = 1;
                grid[GridSize, i] = 1;
            }

            //Working "backwards" purely to follow the given problem
            for (int x = GridSize - 1; x >= 0; x--)
            {
                for (int y = GridSize - 1; y >= 0; y--)
                {
                    //The available choices in any given point are the amount of choices in next/previous choices.
                    grid[x, y] = grid[x + 1, y] + grid[x, y + 1];
                }
            }

            Log.Information("There are {count} routes through a {x} by {x} grid.",
                grid[0, 0], GridSize);
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Ishiika;
using Ishiika.Library;

namespace Problems1_25
{
    public class Problem011 : IIshiikaProblem
    {
        public string ProblemName => "Largest product in a grid";
        public string ProblemURL => $"https://projecteuler.net/problem={ProblemID}";
        public int ProblemID => 11;

        public void Solve()
        {
            const int windowSize = 4;

            var grid = Input();

            List<(int x, int y)> directions =
                new List<(int x, int y)> {
                    (0, 1), //right
                    (1, 0), //down
                    (1, 1), //downright
                    (1, -1) //downleft
            };

            long greatestProduct = 0;
            List<int> cellsForProduct = new();

            for (var x = 0; x < grid.GetLength(0) - windowSize; x++)
            {
                for (var y = 0; y < grid.GetLength(1) - windowSize; y++)
                {
                    foreach (var direction in directions)
                    {
                        //DownLeft is going to end up running out of bounds but since sets of cells less than 4 cannot produce larger products this doesn't matter
                        var cells = CellsAlongPath(x, y, direction, grid, windowSize);

                        long product = cells.Aggregate(1, (acc, val) => acc * val);

                        if (product > greatestProduct)
                        {
                            greatestProduct = product;
                            cellsForProduct = cells;
                        }
                    }
                }
            }

            Log.Information("The greatest product was {greatestProduct:N0} from the cells {@cellsForProduct}", greatestProduct, cellsForProduct);
        }

        public static List<int> CellsAlongPath(int x, int y, (int x, int y) Path, int[,] Grid, int WindowSize)
        {
            var aX = x;
            var aY = y;

            var cells = new List<int>();

            for (int i = 0; i < WindowSize; i++)
            {
                if (aX >= Grid.GetLength(0)
                    || aY >= Grid.GetLength(1)
                    || aX < 0
                    || aY < 0)
                {
                    return cells;
                }

                cells.Add(Grid[aX, aY]);

                aX += Path.x;
                aY += Path.y;
            }

            return cells;
        }

        private int[,] Input()
        {
            var input = inputData.Split(Environment.NewLine);
            var xSize = input.Length;
            var ySize = xSize;

            var data = new int[xSize, ySize];

            int x = 0;

            foreach (var line in input)
            {
                var numbers = line.Trim().Split(" ").Select(n => int.Parse(n)).ToArray();

                for (var y = 0; y < ySize; y++)
                {
                    data[x, y] = numbers[y];
                }
                x++;
            }

            return data;
        }

        private readonly string inputData = @"08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
    }
}
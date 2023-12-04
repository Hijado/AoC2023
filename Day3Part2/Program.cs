using System;
using System.Text;

namespace Day3Part2
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<string> list = File.ReadAllLines("test.txt").ToList();

            int sum = PartTwo(list);
            Console.WriteLine(sum);
        }

        static bool IsValid(int i, int j, int rows, int cols)
        {
            return i >= 0 && i < rows && j >= 0 && j < cols;
        }

        static int PartTwo(List<string> schematic)
        {
            int r = schematic.Count;
            int c = schematic[0].Length;
            List<int> gearRatios = new List<int>();

            for (int rows = 0; rows < r; rows++)
            {
                for (int cols = 0; cols < r; cols++)
                {
                    if (schematic[rows][cols] == '*')
                    {
                        List<int> adjacentNumbers = new List<int>();
                        for (int y = rows - 1; y < rows + 2; y++)
                        {
                            for (int x = cols - 1; x < cols + 2; x++)
                            {
                                if (IsValid(y, x, r, c) && Char.IsDigit(schematic[y][x]))
                                {
                                    int n = FindNumber(schematic, (y, x));

                                    if (adjacentNumbers.Contains(n))
                                        continue;

                                    adjacentNumbers.Add(FindNumber(schematic, (y, x)));
                                }
                            }
                        }

                        if (adjacentNumbers.Count == 2)
                            gearRatios.Add(adjacentNumbers[0] * adjacentNumbers[1]);
                    }
                }
            }

            return gearRatios.Sum();
        }

        static int FindNumber(List<string> schematic, (int, int) tuple)
        {
            StringBuilder sb = new StringBuilder();

            int tuple1y = tuple.Item1;
            int tuple1x = tuple.Item2;

            sb.Append(schematic[tuple1y][tuple1x]);

            int a = 1; int b = -1;

            try
            {
                while (Char.IsDigit(schematic[tuple1y][tuple1x + a]))
                { 
                    sb.Append(schematic[tuple1y][tuple1x + a]);
                    a++;
                }
            }
            catch (Exception) { /* DO NOTHING */ }

            try
            {
                while (Char.IsDigit(schematic[tuple1y][tuple1x + b]))
                {
                    sb.Insert(0, schematic[tuple1y][tuple1x + b]);
                    b--;
                }
            }
            catch (Exception) { /* DO NOTHING */}

            return int.Parse(sb.ToString());
        }
    }
}
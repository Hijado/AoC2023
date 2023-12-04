using System.Text;

namespace Day3Part1
{
    static class Program
    {
        static void Main(string[] args)
        {
            PartOne();
        }

        static void PartOne()
        {
            var lines = File.ReadAllLines("test.txt");

            int colums = lines[0].Length;
            int rows = lines.GetLength(0);

            char[,] grid = new char[rows, colums];
            List<char> symbols = new List<char>() { '&', '*', '=', '+', '-', '/', '@', '$', '#', '%' };
            List<int> numbers = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    bool conditon = false;
                    if (Char.IsDigit(grid[i, j]))
                    {
                        for (int k = i - 1 ; k < i + 2; k++)
                        {
                            for (int l = j - 1;  l < j + 2; l++)
                            {
                                try
                                {
                                    if (symbols.Contains(grid[k, l]))
                                    {
                                        conditon = true;
                                        break;
                                    }
                                }
                                catch (Exception) { /*Ignore because you want to continue*/ }
                            }

                            if (conditon)
                                break;
                        }
                    }

                    if (conditon)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(grid[i, j]);
                        int a = 1; int b = -1;

                        try
                        {
                            while (Char.IsDigit(grid[i, j + a]))
                            {
                                sb.Append(grid[i, j + a]);
                                a++;
                            }
                        }
                        catch (Exception) { /* DO NOTHING */ }

                        try
                        {
                            while (Char.IsDigit(grid[i, j + b]))
                            {
                                sb.Insert(0, grid[i, j + b]);
                                b--;
                            }
                        }
                        catch (Exception) { /* DO NOTHING */}

                        numbers.Add(int.Parse(sb.ToString()));

                        if (j + a > j + 1)
                            j += a;
                    }
                }
            }

            int counter = numbers.Sum();

            Console.WriteLine(counter);
        }
    }
}
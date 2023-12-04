using System.Security.Principal;
using System.Text;

namespace Day4Part1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var list = File.ReadAllLines("test.txt").ToList();
            
            int sum = PartOne(list);
            
            Console.WriteLine(sum);
        }

        static int PartOne(List<string> strings)
        {
            int points = 0;
            foreach (string s in strings)
            {
                var cleanLine = s.Replace(" ", "-");
                List<string> winningNumbers = new List<string>();
                List<string> lotNumbers = new List<string>();
                int counter = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ':')
                        cleanLine = cleanLine.Remove(0, i + 1);
                }

                string[] splits = cleanLine.Split("|");

                StringBuilder sb = new StringBuilder();
                foreach (char c in splits[0]) 
                {
                    if (c == '-' && sb.Length != 0)
                    {
                        winningNumbers.Add(sb.ToString());
                        sb.Clear();
                        continue;
                    }
                    else if (c == '-')
                        continue;

                    sb.Append(c);
                }

                sb.Clear();

                foreach (char c in splits[1])
                {
                    if (c == '-' && sb.Length != 0)
                    {
                        lotNumbers.Add(sb.ToString());
                        sb.Clear();
                        continue;
                    }
                    else if (c == '-')
                        continue;

                    sb.Append(c);
                }
                lotNumbers.Add(sb.ToString());

                foreach (string lot in lotNumbers)
                {
                    if (winningNumbers.Contains(lot))
                    {
                        counter = counter == 0 ? 1 : counter * 2;
                    }
                }

                points += counter;
            }
            return points;
        }
    }
}
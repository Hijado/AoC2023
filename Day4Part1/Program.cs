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
                int colonIndex = s.IndexOf(':');
                string[] splits = s.Substring(colonIndex + 1).Split('|');

                HashSet<string> winningNumbers = new HashSet<string>(splits[0].Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries));
                HashSet<string> lotNumbers = new HashSet<string>(splits[1].Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries));

                int counter = lotNumbers.Count(lot => winningNumbers.Contains(lot));

                points += counter > 0 ? (1 << counter) : 0; // Using bitwise left shift instead of repeated multiplication
            }
            return points / 2;
        }
    }
}
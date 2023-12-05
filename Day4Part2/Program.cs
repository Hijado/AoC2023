using Microsoft.VisualBasic;
using System.Text;

namespace Day4Part2
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<string> list = File.ReadAllLines("test.txt").ToList();
            List<string> list2 = File.ReadAllLines("test.txt").ToList();
            int sum = PartTwo(list, list2);

            Console.WriteLine(sum);
        }

        static int PartTwo(List<string> strings, List<string> stringsCopy)
        {
            Queue<string> queue = new Queue<string>(strings);
            List<string> queueCopy = new List<string>(stringsCopy);
            int points = 0;

            while (queue.Count > 0)
            {
                string line = queue.Dequeue();
                points++;

                int colonIndex = line.IndexOf(':');
                int cardNumber = int.Parse(line.Substring(5, colonIndex - 5).Trim());

                string[] splits = line.Substring(colonIndex + 1).Split('|');

                string[] winningNumbers = splits[0].Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string[] lotNumbers = splits[1].Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                int counter = lotNumbers.Count(lot => winningNumbers.Contains(lot));

                for (int i = cardNumber; i < cardNumber + counter; i++)
                {
                    queue.Enqueue(queueCopy[i]);
                }
            }

            return points;
        }
    }
}
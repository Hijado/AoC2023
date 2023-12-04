using System.Diagnostics.Metrics;

namespace Day2Part1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            PartOne();
        }

        static void PartOne()
        {
            var lines = File.ReadAllLines("test.txt");
            int counter = 0;
            Dictionary<int, char> keyValuePairs = new Dictionary<int, char>
                                                                { { 12, 'r' },
                                                                  { 13, 'g' },
                                                                  { 14, 'b' } };

            foreach (var line in lines)
            {
                var cleanLine = line
                                .Replace("blue", "b")
                                .Replace("red", "r")
                                .Replace("green", "g")
                                .Replace(" ", "");

                char[] seperators = { ',', ';', ':'};
                List<string> list = cleanLine.Split(seperators).ToList();

                string gameID = list[0].Remove(0, 4);
                int gameIndex = int.Parse(gameID);
                list.RemoveAt(0);
                bool condition = false;

                foreach (string s in list)
                {
                    char color = s[s.Length - 1];
                    string newS = s.Remove(s.Length - 1);
                    int key = int.Parse(newS);

                    foreach (KeyValuePair<int, char> pair in keyValuePairs)
                    {
                        if (pair.Key < key && pair.Value == color)
                        {
                            condition = true; 
                            break;
                        }
                    }

                    if (condition)
                        break;
                }

                if (!condition)
                    counter += gameIndex;
            }

            Console.WriteLine(counter);
        }
    }
}
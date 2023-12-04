namespace Day2Part2
{
    static class Program
    {
        static void Main(string[] args)
        {
            PartTwo();
        }

        static void PartTwo()
        {
            var lines = File.ReadAllLines("test.txt");
            int counter = 0;

            foreach (var line in lines)
            {
                var cleanLine = line
                                .Replace("blue", "b")
                                .Replace("red", "r")
                                .Replace("green", "g")
                                .Replace(" ", "");

                char[] seperators = { ',', ';', ':' };
                List<string> list = cleanLine.Split(seperators).ToList();

                list.RemoveAt(0);

                Dictionary<char, int> keyValuePairs = new Dictionary<char, int>() 
                                                                    { { 'r', 0 },
                                                                      { 'b', 0 },
                                                                      { 'g', 0 } };

                foreach (string s in list)
                {
                    char color = s[s.Length - 1];
                    string newS = s.Remove(s.Length - 1);
                    int key = int.Parse(newS);

                    foreach (KeyValuePair<char, int> pair in keyValuePairs)
                    {
                        if (pair.Value < key && pair.Key == color)
                        {
                            keyValuePairs[pair.Key] = key;
                        }
                    }
                }

                counter += keyValuePairs['r'] * keyValuePairs['b'] * keyValuePairs['g'];
            }

            Console.WriteLine(counter);
        }
    }
}
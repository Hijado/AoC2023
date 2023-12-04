namespace Day1Part2
{
    public static class Program
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
                                .Replace("one", "o1e")
                                .Replace("two", "t2o")
                                .Replace("three", "t3e")
                                .Replace("four", "f4r")
                                .Replace("five", "f5e")
                                .Replace("six", "s6x")
                                .Replace("seven", "s7n")
                                .Replace("eight", "e8t")
                                .Replace("nine", "n9e");

                var first = cleanLine.First(Char.IsDigit);
                var last = cleanLine.Last(Char.IsDigit);

                var combined = first.ToString() + last.ToString();
                counter += int.Parse(combined);
            }

            Console.WriteLine(counter);
        }
    }
}
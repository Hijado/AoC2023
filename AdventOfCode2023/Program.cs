namespace Day1Part1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PartOne();
        }

        public static void PartOne()
        {
            var lines = File.ReadAllLines("test.txt");
            int counter = 0;

            foreach (var line in lines)
            {
                var first = line.First(Char.IsDigit);
                var last = line.Last(Char.IsDigit);

                var combined = first.ToString() + last.ToString();
                counter += int.Parse(combined);
            }

            Console.WriteLine(counter);
        }
    }
}
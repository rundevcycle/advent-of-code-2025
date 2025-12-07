using System.IO;

namespace AoC_Day03
{
    public class Program
    {
        public static bool DebugOn { get; set; } = false;

        static void Main(string[] args)
        {
            // Read input from a text file.
            if (args.Length < 1)
            {
                throw new ArgumentException("Must provide a filename argument.");
            }

            if (args.Length == 2 && args[1] == "-d")
            {
                DebugOn = true;
            }

            string filename = args[0];
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"Unable to locate file: {filename}");
            }

            string inputData = File.ReadAllText(filename).Replace("\r", "");

//            var part1 = new Part1(inputData);
//            part1.Run();

            var part2 = new Part2(inputData);
            part2.Run();
        }
    }
}

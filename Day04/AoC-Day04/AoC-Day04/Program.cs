using System.IO;

namespace AoC_Day04
{
    internal class Program
    {
        public static bool DebugOn { get; set; } = false;

        static void Main(string[] args)
        {
            // Parameters: Day#  DebugYN  file


            // Read input from a text file.
            if (args.Length < 3)
            {
                throw new ArgumentException("Must provide part #, debug (Y/N), and filename arguments.");
            }

            int part = int.Parse(args[0]);

            if (args[1].ToUpper() == "Y")
            {
                DebugOn = true;
            }

            string filename = args[2];
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"Unable to locate file: {filename}");
            }

            List<string> inputData = File.ReadAllText(filename)
                .Replace("\r", "")
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            switch (part)
            {
                case 1:
                    var part1 = new Part1(inputData);
                    part1.Run();
                    break;

                case 2:
                    var part2 = new Part2(inputData);
                    part2.Run();
                    break;

                default:
                    throw new ArgumentException("Invalid part number.");
            }
        }
    }
}

using System.Diagnostics;
using System.IO;

namespace AoC2025
{
    internal class Program
    {
        public static bool DebugMode { get; set; }


        static void Main(string[] args)
        {
            // Parameters: day#, part#, debug Y/N, and file

            if (args.Length < 4)
            {
                throw new ArgumentException("Must provide day #, part #, debug (Y/N), and filename.");
            }

            int day = int.Parse(args[0]);
            int part = int.Parse(args[1]);

            if (args[2].ToUpper() == "Y")
            {
                DebugMode = true;
            }

            string filename = args[3];
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"Unable to locate file: {filename}");
            }

            List<string> inputData = File.ReadAllText(filename)
                .Replace("\r", "")
                .Split("\n")
                .ToList();


            var dailyPuzzle = DailyPuzzleFactory.Create(day, inputData);
            dailyPuzzle.Run(part);


            //switch (part)
            //{
            //    case 1:
            //        var part1 = new Part1(inputData);
            //        part1.Run();
            //        break;

            //    case 2:
            //        var part2 = new Part2(inputData);
            //        part2.Run();
            //        break;

            //    default:
            //        throw new ArgumentException("Invalid part number.");
            //}
        }
    }
}

using log4net;
using log4net.Config;
using System.Diagnostics;
using System.IO;

namespace AoC2025
{
    internal class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        static int Main(string[] args)
        {
            // Parameters: day#, part#, and file

            try
            {
                XmlConfigurator.Configure(new FileInfo("log4net.config"));

                if (args.Length < 3)
                {
                    logger.Fatal("Must provide day #, part #, and filename.");
                    return -99;
                }

                int day = int.Parse(args[0]);
                int part = int.Parse(args[1]);

                string filename = args[2];
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
            } 
            catch (Exception ex)
            {
                logger.Fatal($"Unhandled exception: {ex.Message}", ex);
                return -1;
            }
            return 0;
        }
    }
}

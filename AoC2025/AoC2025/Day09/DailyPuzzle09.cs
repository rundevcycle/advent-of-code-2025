using log4net;
using System.Runtime.CompilerServices;

namespace AoC2025.Day09
{
    internal class DailyPuzzle09 : DailyPuzzle
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DailyPuzzle09));


        public DailyPuzzle09(List<string> inputData) : base(inputData) { }



        protected override void RunPart1()
        {
            // Load list of strings into a list of tiles.
            List<TilePoint> tiles = new();
            foreach (var line in InputData.Where(l => !string.IsNullOrWhiteSpace(l))) 
            {
                tiles.Add(new TilePoint(line));
            }
            logger.Debug($"There are {tiles.Count} tiles.");


            List<Rectangle> rectangles = new();
            for (int i = 0; i < tiles.Count; i++)
            {
                for (int j = i + 1; j < tiles.Count; j++)
                {
                    rectangles.Add(new Rectangle(tiles[i], tiles[j]));
                }
            }

            var largestArea = rectangles.OrderByDescending(r => r.Area).First();
            logger.Info($"Largest area is {largestArea.Area} between tiles {largestArea.Tile1} and {largestArea.Tile2}.");


        }



        protected override void RunPart2()
        {
            throw new NotImplementedException();
        }
    }
}

namespace AoC2025.Day09
{
    internal class TilePoint
    {
        public long X { get; set; }
        public long Y { get; set; }


        public TilePoint(long x, long y)
        {
            X = x;
            Y = y;
        }


        public TilePoint(string coords)
        {
            // Coordinates are reversed in this puzzle.
            var arr = coords.Split(",");
            X = long.Parse(arr[1]);
            Y = long.Parse(arr[0]);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}

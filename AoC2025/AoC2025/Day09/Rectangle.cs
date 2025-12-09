namespace AoC2025.Day09
{
    internal class Rectangle
    {
        public TilePoint Tile1 { get; private set; }
        public TilePoint Tile2 { get; private set; }
        public long Area { get; private set; }

        public Rectangle(TilePoint tile1, TilePoint tile2)
        {
            Tile1 = tile1;
            Tile2 = tile2;
            var width = Math.Abs(tile1.X - tile2.X) + 1;
            var height = Math.Abs(tile1.Y - tile2.Y) + 1;
            Area = width * height;
        }

    }
}

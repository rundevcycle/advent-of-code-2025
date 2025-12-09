namespace AoC2025.Day08
{
    internal struct JBPoint
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public JBPoint(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public JBPoint(string coords)
        {
            var arr = coords.Split(",");
            X = long.Parse(arr[0]);
            Y = long.Parse(arr[1]);
            Z = long.Parse(arr[2]);
        }


        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

    }
}

namespace AoC2025.Day08
{
    internal class StringLight
    {
        public JBPoint Box1 { get; private set; }
        public JBPoint Box2 { get; private set; }
        public double Distance { get; private set; }

        public StringLight(JBPoint box1, JBPoint box2)
        {
            Box1 = box1;
            Box2 = box2;
            Distance = Math.Sqrt(
                Math.Pow((box1.X - box2.X), 2) 
                + Math.Pow((box1.Y - box2.Y), 2)
                + Math.Pow((box1.Z-box2.Z), 2)
            );
        }
    }
}

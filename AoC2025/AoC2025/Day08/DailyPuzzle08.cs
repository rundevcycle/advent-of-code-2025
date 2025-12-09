using log4net;

namespace AoC2025.Day08
{
    internal class DailyPuzzle08 : DailyPuzzle
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DailyPuzzle08));


        public DailyPuzzle08(List<string> inputData) : base(inputData) { }


        protected override void RunPart1()
        {
            List<JBPoint> junctionBoxes = new();

            // Convert all the lines into JBPoints.
            foreach (var line in InputData)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                junctionBoxes.Add(new JBPoint(line));
            }

            // Figure out all the potential string lights that would be needed to connect every box.
            List<StringLight> stringLights = new();
            for (int i = 0; i < junctionBoxes.Count; i++)
            {
                for (int j = i + 1; j < junctionBoxes.Count; j++)
                {
                    stringLights.Add(new StringLight(junctionBoxes[i], junctionBoxes[j]));
                }
            }

            CircuitManager circManager = new CircuitManager();

            // Display the shortest 10 connections.
            foreach (var light in stringLights.OrderBy(l => l.Distance).Take(1000))
            {
                logger.Debug($"From {light.Box1} to {light.Box2} is {light.Distance}.");
                circManager.AddStringLight(light);
            }

            foreach (var circ in circManager.Circuits.OrderByDescending(c => c.JunctionBoxes.Count))
            {
                logger.Debug($"Circuit {circ.Id} has {circ.JunctionBoxes.Count} boxes.");
            }


            long finalResult = 1;
            foreach (var circ in circManager.Circuits.OrderByDescending(c => c.JunctionBoxes.Count).Take(3))
            {
                finalResult *= circ.JunctionBoxes.Count;
            }
            logger.Info($"Final result is {finalResult}.");
        }



        protected override void RunPart2()
        {
            throw new NotImplementedException();
        }
    }
}

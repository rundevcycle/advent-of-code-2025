using log4net;
using System.Collections.ObjectModel;

namespace AoC2025.Day08
{
    internal class CircuitManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CircuitManager));

        private List<Circuit> _circuits = new();
        public ReadOnlyCollection<Circuit> Circuits { get { return _circuits.AsReadOnly(); } }


        public void AddStringLight(StringLight stringLight)
        {
            var c1 = FindCircuit(stringLight.Box1);
            var c2 = FindCircuit(stringLight.Box2);

            // If neither box is in a circuit, add a new circuit.
            if (c1 == null && c2 == null)
            {
                var circuit = new Circuit();
                circuit.AddJunction(stringLight.Box1);
                circuit.AddJunction(stringLight.Box2);
                _circuits.Add(circuit);
                logger.Debug($"Adding a new circuit {circuit.Id} for {stringLight.Box1} - {stringLight.Box2}.");
                return;
            }

            // If one box in a circuit and the other isn't, add it to the existing circuit.
            if (c1 != null && c2 == null)
            {
                c1.AddJunction(stringLight.Box2);
                logger.Debug($"Adding box {stringLight.Box2} to circuit {c1.Id}.");
                return;
            } 
            else if (c1 == null && c2 != null)
            {
                c2.AddJunction(stringLight.Box1);
                logger.Debug($"Adding box {stringLight.Box1} to circuit {c2.Id}.");
                return;
            }

            // If both boxes are in different circuits, merge the circuits together.
            if (c1 != null && c2 != null && c1.Id != c2.Id)
            {
                logger.Debug($"Merging circuit {c2.Id} ({c2.JunctionBoxes.Count} boxes) into circuit {c1.Id} ({c1.JunctionBoxes.Count} boxes).");
                c1.MergeCircuit(c2);
                _circuits.Remove(c2);
                return;
            }

            // Both boxes are in the same circuit.
        }



        private Circuit? FindCircuit(JBPoint box)
        {
            foreach (var circuit in _circuits)
            {
                if (circuit.JunctionBoxes.Contains(box))
                {
                    return circuit;
                }
            }
            return null;
        }

    }
}

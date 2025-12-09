using System.Collections.ObjectModel;

namespace AoC2025.Day08
{
    internal class Circuit
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        private List<JBPoint> _junctionBoxes = new();
        public ReadOnlyCollection<JBPoint> JunctionBoxes {  get { return _junctionBoxes.AsReadOnly(); } }

        public void AddJunction(JBPoint box)
        {
            if (!_junctionBoxes.Contains(box))
            {
                _junctionBoxes.Add(box);
            }
        }


        public void MergeCircuit(Circuit circuit)
        {
            foreach (var box in circuit.JunctionBoxes)
            {
                AddJunction(box);
            }
        }

    }
}

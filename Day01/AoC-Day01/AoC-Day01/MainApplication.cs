using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;



namespace AoC_Day01
{
    internal class MainApplication
    {
        private string _inputData = "";

        private List<int> _dialPositions = new List<int>();


        public MainApplication(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            int numLines = _inputData.Split("\n").Length;
            Console.WriteLine($"Input contains {numLines} lines of text.");

            int currentPosition = 50;
            _dialPositions.Add(currentPosition);
            Console.WriteLine($"Starting at position {currentPosition}.");

            foreach (var line in _inputData.Split("\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string direction = line.Substring(0, 1);
                int amount = int.Parse(line.Substring(1));

                switch (direction)
                {
                    case "R":
                        currentPosition = (currentPosition + amount) % 100;
                        break;
                    case "L":
                        currentPosition = (currentPosition - amount) % 100;
                        break;
                    default:
                        throw new Exception($"Invalid direction: {direction}.");
                }

                if (currentPosition < 0)
                {
                    currentPosition += 100;
                }
                _dialPositions.Add(currentPosition);
                Console.WriteLine($"Turn {line} to {currentPosition}.");
            }

            Console.WriteLine($"There are {_dialPositions.Count(d => d == 0)} instances of 0.");

            

        }
    }
}

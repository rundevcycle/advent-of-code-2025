using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day01
{
    internal class Part2
    {
        private string _inputData = "";

        public Part2(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            int numLines = _inputData.Split("\n").Length;
            Console.WriteLine($"Input contains {numLines} lines of text.");

            int numTimesAtZero = 0;

            int lastPosition = 50;
            Console.WriteLine($"Starting at position {lastPosition}.");

            foreach (var line in _inputData.Split("\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string direction = line.Substring(0, 1);
                int amount = int.Parse(line.Substring(1));

                Console.WriteLine($"Starting from {lastPosition}, turn {line}.");

                int numFullRotations = amount / 100;
                amount = amount % 100;

                if (numFullRotations > 0)
                {
                    numTimesAtZero += numFullRotations;
                    Console.WriteLine($"    ... passed through 0 by {numFullRotations} full rotations.");
                }

                if (amount == 0)
                {
                    Console.WriteLine("    ... ending in same position.");
                    continue;
                }

                int nextPosition = 0;
                switch (direction)
                {
                    case "R":
                        nextPosition = (lastPosition + amount) % 100;
                        break;
                    case "L":
                        nextPosition = (lastPosition - amount) % 100;
                        break;
                    default:
                        throw new Exception($"Invalid direction: {direction}.");
                }

                if (nextPosition < 0)
                {
                    nextPosition += 100;
                }

                if (nextPosition == 0)
                {
                    Console.WriteLine("    ... stopped at 0.");
                    numTimesAtZero++;
                } 
                else if (PassThroughZero(direction, lastPosition, nextPosition))
                {
                    Console.WriteLine("    ... passed through 0.");
                    numTimesAtZero++;
                }

                Console.WriteLine($"    ... ended at {nextPosition}.");
                lastPosition = nextPosition;
            }

            Console.WriteLine($"Passed through zero {numTimesAtZero} times.");
        }


        private bool PassThroughZero(string direction, int lastPosition, int nextPosition)
        {
            if (direction == "R" && lastPosition != 0 && nextPosition < lastPosition)
            {
                return true;
            }

            if (direction == "L" && lastPosition != 0 && nextPosition > lastPosition)
            {
                return true;
            }

            return false;
        }
    }
}

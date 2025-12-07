using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day03
{
    internal class Part1
    {
        private List<string> _inputData = new();

        public Part1(string inputData)
        {
            _inputData = inputData.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
        }


        public void Run()
        {
            int totalJoltage = 0;

            int lineCount = 0;

            foreach(var line in _inputData)
            {
                int tens = 0;
                int units = 0;
                int tensPosition = 0;

                lineCount++;
//                Console.WriteLine($"Line {lineCount}...");

                int joltage = 0;

                for (int i = 0; i < (line.Length - 1); i++)
                {
                    int val = int.Parse(line[i].ToString());
                    if (val > tens)
                    {
                        tens = val;
                        tensPosition = i;
//                        Console.WriteLine($"    Max tens at position {i}: {tens}");
                    }
                }

                for (int i = tensPosition + 1; i < line.Length; i++)
                {
                    int val = int.Parse(line[i].ToString());
                    if (val > units)
                    {
                        units = val;
//                        Console.WriteLine($"    Max units at position {i}: {units}");
                    }
                }

                joltage = tens * 10 + units;

                Console.WriteLine($"Line {lineCount} max is {joltage}.");
                totalJoltage += joltage;
            }

            Console.WriteLine($"Total Joltage: {totalJoltage}.");
        }
    }
}

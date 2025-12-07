using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day03
{
    internal class Part2
    {
        private List<string> _inputData = new();

        public Part2(string inputData)
        {
            _inputData = inputData.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
        }


        public void Run()
        {
            long totalJoltage = 0;

            int lineCount = 0;

            foreach(var line in _inputData)
            {
                lineCount++;
                if (Program.DebugOn)
                {
                    Console.WriteLine($"Line {lineCount}...");
                }

                int lastPosition = -1;

                long joltage = 0;
                for (int a = 0; a < 12; a++)
                {
                    int maxVal = 0;

                    for (int i = lastPosition + 1; i < line.Length + 1 - 12 + a; i++)
                    {
                        int val = int.Parse(line[i].ToString());
                        if (val > maxVal)
                        {
                            maxVal = val;
                            lastPosition = i;
                            if (Program.DebugOn)
                            {
                                Console.WriteLine($"    Digit {a+1}: {maxVal} @ {i}");
                            }
                        }
                    }
                    joltage = joltage * 10 + maxVal;
                }

                if (Program.DebugOn)
                {
                    Console.WriteLine($"Line {lineCount} max is {joltage}.");
                }
                totalJoltage += joltage;
            }

            Console.WriteLine($"Total Joltage: {totalJoltage}.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day04
{
    public class Part2
    {
        private List<string> _inputData = new();

        public Part2(List<string> inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            int rollsThatCanBeMoved = 0;
            int maxCharsPerLine = MaxCharsPerLine();

            List<string> previousGrid = PadEdges(_inputData);

            while (true)
            {
                int rollsMovedThisPass = 0;
                List<string> revisedGrid = previousGrid;

                for (int lineNumber = 1; lineNumber <= _inputData.Count; lineNumber++)
                {
                    string[] tempGrid = new string[3];
                    tempGrid[0] = previousGrid[lineNumber - 1];
                    tempGrid[1] = previousGrid[lineNumber];
                    tempGrid[2] = previousGrid[lineNumber + 1];

                    if (Program.DebugOn)
                    {
                        Console.WriteLine($"Line #{lineNumber}...");
                        Console.WriteLine($"    {tempGrid[0]}");
                        Console.WriteLine($"    {tempGrid[1]}");
                        Console.WriteLine($"    {tempGrid[2]}");
                    }

                    // Now that tempGrid is set up, we can look at each character in the middle row 
                    // (except the first and last) and count the number of rolls around it.
                    for (int c = 1; c <= maxCharsPerLine; c++)
                    {
                        if (tempGrid[1][c] != '@')
                        {
                            continue;
                        }

                        int rollsAround = 0;
                        if (tempGrid[0][c - 1] == '@') rollsAround++;
                        if (tempGrid[0][c] == '@') rollsAround++;
                        if (tempGrid[0][c + 1] == '@') rollsAround++;

                        if (tempGrid[1][c - 1] == '@') rollsAround++;
                        if (tempGrid[1][c + 1] == '@') rollsAround++;

                        if (tempGrid[2][c - 1] == '@') rollsAround++;
                        if (tempGrid[2][c] == '@') rollsAround++;
                        if (tempGrid[2][c + 1] == '@') rollsAround++;

                        if (rollsAround < 4)
                        {
                            rollsMovedThisPass++;
                            rollsThatCanBeMoved++;
                            Console.WriteLine($"We can move row {lineNumber + 1}, roll in {c}");
                            char[] revisedLineChars = revisedGrid[lineNumber].ToCharArray();
                            revisedLineChars[c] = '.';
                            revisedGrid[lineNumber] = new string(revisedLineChars);
                        }
                    }
                }

                if (rollsMovedThisPass > 0)
                {
                    previousGrid = revisedGrid;
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"We can move {rollsThatCanBeMoved} rolls.");
        }


        private List<string> PadEdges(List<string> originalStockpile)
        {
            int maxCharsPerLine = MaxCharsPerLine();

            List<string> paddedStockpile = new();
            paddedStockpile.Add(EmptyRow(maxCharsPerLine + 2));
            foreach(var line in originalStockpile)
            {
                paddedStockpile.Add($".{line}.");
            }
            paddedStockpile.Add(EmptyRow(maxCharsPerLine + 2));

            return paddedStockpile;
        }


        private int MaxCharsPerLine()
        {
            int numChars = -1;

            foreach (var line in _inputData)
            {
                if (numChars < 0)
                {
                    numChars = line.Length;
                }
                else
                {
                    if (line.Length != numChars)
                    {
                        throw new InvalidDataException("Rows are not all the same length.");
                    }
                }
            }

            return numChars;
        }


        private string EmptyRow(int numPlaces)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numPlaces; i++)
            {
                sb.Append(".");
            }
            return sb.ToString();
        }
    }
}

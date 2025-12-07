using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day04
{
    public class Part1
    {
        private List<string> _inputData = new();

        public Part1(List<string> inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            int rollsThatCanBeMoved = 0;

            int lastLineNumber = _inputData.Count();

            int maxCharsPerLine = MaxCharsPerLine();


            for (int lineNumber = 0; lineNumber < _inputData.Count; lineNumber++)
            {
                string[] tempGrid = new string[3];

                // The first and last row are special cases.
                // The first and last character of each line are special cases.

                if (lineNumber == 0)
                {
                    tempGrid[0] = EmptyRow(maxCharsPerLine + 2);
                } else
                {
                    tempGrid[0] = $".{_inputData[lineNumber - 1]}.";
                }

                tempGrid[1] = $".{_inputData[lineNumber]}.";

                if (lineNumber + 1 >= lastLineNumber)
                {
                    tempGrid[2] = EmptyRow(maxCharsPerLine + 2);
                }
                else
                {
                    tempGrid[2] = $".{_inputData[lineNumber + 1]}.";
                }


                if (Program.DebugOn) 
                {
                    Console.WriteLine($"Line #{lineNumber + 1}...");
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
                    if (tempGrid[0][c - 1] == '@')  rollsAround++;
                    if (tempGrid[0][c] == '@') rollsAround++;
                    if (tempGrid[0][c + 1] == '@') rollsAround++;

                    if (tempGrid[1][c - 1] == '@') rollsAround++;
                    if (tempGrid[1][c + 1] == '@') rollsAround++;

                    if (tempGrid[2][c - 1] == '@') rollsAround++;
                    if (tempGrid[2][c] == '@') rollsAround++;
                    if (tempGrid[2][c + 1] == '@') rollsAround++;

                    if (rollsAround < 4)
                    {
                        rollsThatCanBeMoved++;
                        Console.WriteLine($"We can move row {lineNumber + 1}, roll in {c}");
                    }
                }
            }

            Console.WriteLine($"We can move {rollsThatCanBeMoved} rolls.");
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

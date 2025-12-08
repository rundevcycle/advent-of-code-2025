using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025.Day06
{
    internal class DailyPuzzle06 : DailyPuzzle
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DailyPuzzle06));

        public DailyPuzzle06(List<string> inputData) : base(inputData)
        {
        }


        protected override void RunPart1()
        {
            long grandTotal = 0;
            List<string> opCodes = new();
            List<List<int>> numbers = new();

            // Split input into separate numbers.
            foreach (var line in InputData)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var fields = line.TrimStart(' ').Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(fields[0], out _))
                {
                    // This is a series of numbers.
                    List<int> nums = new();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        nums.Add(int.Parse(fields[i]));
                    }
                    numbers.Add(nums);
                }
                else
                {
                    opCodes = fields.ToList();
                }
            }

            // Add or multiply the numbers in each column.
            for (int i = 0; i < numbers.FirstOrDefault()?.Count; i++)
            {
                long result = numbers.First()[i];
                string op = opCodes[i];
                logger.Debug($"Column {i + 1}, operation ='{op}'.");

                for (int j = 1; j < numbers.Count; j++)
                {
                    switch (op)
                    {
                        case "*":
                            result *= numbers[j][i];
                            break;
                        case "+":
                            result += numbers[j][i];
                            break;
                        default:
                            throw new NotImplementedException($"Invalid operation '{op}'.");
                    }
                }
                logger.Debug($"Column {i + 1}, result of {op} is {result}.");
                grandTotal += result;
            }
            logger.Info($"Grand total is {grandTotal}.");
            
        }

        protected override void RunPart2()
        {
            long grandTotal = 0;

            // Spaces are now relevant!
            // The start of each columns is defined by the position of the op code.  

            // How many lines are numbers?
            int numNumberLines = 0;
            string opCodes = "";
            foreach (var line in InputData) 
            {
                if (line.StartsWith('*') || line.StartsWith('+'))
                {
                    opCodes = line;
                    break;
                }
                else
                {
                    numNumberLines++;
                }
            }
            logger.Debug($"There are {numNumberLines} lines of numbers.");

            var colRanges = GetColumnRanges(opCodes);

            int columnCounter = 0;
            foreach (var col in colRanges)
            {
                columnCounter++;

                // Build up the numbers, from right-to-left, top-to-bottom.
                // There might be spaces, which are ignored.
                long result = 0;
                string opCode = opCodes.Substring(col.Item1, col.Item2 - col.Item1 + 1).Trim();
                if (opCode == "*")
                {
                    result = 1;
                }
                for (int i = col.Item2; i >= col.Item1; i--)
                {
                    string currNumStr = "";
                    for (int lineNum = 0; lineNum < numNumberLines; lineNum++)
                    {
                        if (InputData[lineNum][i] == ' ')
                        {
                            continue;
                        }
                        else
                        {
                            currNumStr = currNumStr + InputData[lineNum][i];
                        }
                    }
                    if (string.IsNullOrEmpty(currNumStr))
                    {
                        continue;
                    }
                    int currNum = int.Parse(currNumStr);
                    logger.Debug($"Column {columnCounter}, position {i}: {currNum}");
                    
                    switch (opCode)
                    {
                        case "+":
                            result += currNum;
                            break;
                        case "*":
                            result *= currNum;
                            break;
                        default:
                            throw new ArgumentException($"Invalid opcode '{opCode}'");
                    }
                }
                logger.Debug($"Line {columnCounter} result is {result}.");
                grandTotal += result;
            }

            logger.Info($"The grand total is {grandTotal}.");
        }


        private List<Tuple<int, int>> GetColumnRanges(string opCodes)
        {
            List<Tuple<int, int>> cols = new();

            // Look at the op codes in the last line.
            List<int> startingPositions = new();

            logger.Debug($"OpCodes = '{opCodes.Replace(" ", ".")}'");

            for (int i = 0; i < opCodes.Length; i++)
            {
                if (opCodes[i] == ' ')
                {
                    continue;
                }
                else
                {
                    startingPositions.Add(i);
                    logger.Debug($"Starting position for opCode {opCodes[i]} is {i}.");
                }
            }

            for (int s = 0; s < startingPositions.Count - 1; s++)
            {
                cols.Add(new Tuple<int, int>(startingPositions[s], startingPositions[s + 1] - 1));
            }
            cols.Add(new Tuple<int, int>(startingPositions.Last(), opCodes.Length - 1));

            int colCounter = 0;
            foreach (var col in cols)
            {
                colCounter++;
                logger.Debug($"Column {colCounter}: {col.Item1}-{col.Item2}");
            }


            return cols;
        }
    }
}

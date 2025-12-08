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

        private List<string> opCodes = new();
        private List<List<int>> numbers = new();

        public DailyPuzzle06(List<string> inputData) : base(inputData)
        {
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
        }


        protected override void RunPart1()
        {
            long grandTotal = 0;

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
            throw new NotImplementedException();
        }
    }
}

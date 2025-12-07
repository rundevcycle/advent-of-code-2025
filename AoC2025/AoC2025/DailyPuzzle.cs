using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal abstract class DailyPuzzle
    {
        protected List<string> InputData { get; private set; } = new();

        protected DailyPuzzle(List<string> inputData)
        {
            InputData = inputData;
        }


        public void Run(int part)
        {
            switch(part)
            {
                case 1:
                    RunPart1();
                    break;
                case 2:
                    RunPart2();
                    break;
                default:
                    throw new ArgumentException($"Invalid part {part}.  Must be 1 or 2.");
            }
        }


        protected abstract void RunPart1();

        protected abstract void RunPart2();

    }
}

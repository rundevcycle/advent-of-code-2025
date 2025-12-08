using log4net;
using System.Text;

namespace AoC2025.Day07
{
    internal class DailyPuzzle07 : DailyPuzzle
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DailyPuzzle07));

        public DailyPuzzle07(List<string> inputData) : base(inputData) { }


        protected override void RunPart1()
        {
            // Find the S in the first line.
            int maxSlots = InputData.First().Length;
            bool[] slots = new bool[maxSlots];

            int startingS = InputData.First().IndexOf("S");
            slots[startingS] = true;

            int numSplits = 0;

            for (int line = 1; line < InputData.Count; line++)
            {
                logger.Debug(InputData[line]);
                for (int p = 0; p < InputData[line].Length; p++)
                {
                    if (InputData[line][p] == '^')
                    {
                        if (slots[p])
                        {
                            numSplits++;
                        }
                        slots[p] = false;

                        if (p == 0)
                        {
                            slots[p + 1] = true;
                        }
                        else if (p == InputData[line].Length - 1)
                        {
                            slots[p - 1] = true;
                        }
                        else
                        {
                            slots[p - 1] = true;
                            slots[p + 1] = true;
                        }
                    }
                }
                DumpSlots(slots);
            }

            logger.Info($"There are {slots.Count(s => s == true)} active slots after {numSplits} splits.");
        }



        private void DumpSlots(bool[] slots)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i])
                {
                    sb.Append("|");
                }
                else
                {
                    sb.Append(".");
                }
            }
            logger.Debug(sb.ToString());
        }


        protected override void RunPart2()
        {
            // Find the S in the first line.
            int maxSlots = InputData.First().Length;
            long[] slots = new long[maxSlots];

            int startingS = InputData.First().IndexOf("S");
            slots[startingS] = 1;

            for (int line = 1; line < InputData.Count; line++)
            {
                logger.Debug(InputData[line]);
                for (int p = 0; p < InputData[line].Length; p++)
                {
                    if (InputData[line][p] == '^')
                    {
                        if (p == 0)
                        {
                            slots[p + 1] += slots[p];
                        }
                        else if (p == InputData[line].Length - 1)
                        {
                            slots[p - 1] += slots[p];
                        }
                        else
                        {
                            slots[p - 1] += slots[p];
                            slots[p + 1] += slots[p];
                        }

                        slots[p] = 0;

                    }
                }
                DumpLongSlots(slots);
            }

            logger.Info($"There are {slots.Sum(s => s)} paths.");
        }


        private void DumpLongSlots(long[] slots)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("_");
            for (int i = 0; i < slots.Length; i++)
            {
                sb.Append($"{slots[i]}_");
            }
            logger.Debug(sb.ToString());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day02
{
    internal class Part1
    {
        private string _inputData = "";

        public Part1(string inputData)
        {
            _inputData = inputData;
        }


        public void Run()
        {
            long grandSum = 0;

            foreach (var line in _inputData.Split('\n'))
            {
                foreach (var range in line.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    string startStr = range.Split('-')[0];
                    string endStr = range.Split('-')[1];

                    long startNum = long.Parse(startStr);
                    long endNum = long.Parse(endStr);

                    Console.WriteLine($"Range {range}: {startNum} to {endNum}");

                    for (long i = startNum; i <= endNum; i++)
                    {
                        string str = string.Format($"{i}");
                        int len = str.Length;
                        if (len % 2 != 0)
                        {
                            continue;
                        }

                        string firstHalf = str.Substring(0, len / 2);
                        string lastHalf = str.Substring(len / 2);
//                        Console.WriteLine($"    {i}: {firstHalf} {lastHalf}");

                        if (firstHalf == lastHalf)
                        {
                            Console.WriteLine($"    Dummy: {i}");
                            grandSum += i;
                        }
                    }
                }

            }

            Console.WriteLine($"\nTotal sum of dummy entries is {grandSum}.\n");



        }
    }
}

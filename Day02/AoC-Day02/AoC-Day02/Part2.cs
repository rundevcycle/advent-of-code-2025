using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day02
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

                        if (len <= 1)
                        {
                            continue;
                        }

                        for (int chunkSize = len / 2; chunkSize >= 1; chunkSize--)
                        {
                            var chunks = SplitIntoChunks(str, chunkSize);
                            if (chunks.Count == 0)
                            {
                                continue;
                            }

                            if (AllChunksMatch(chunks))
                            {
                                grandSum += i;
                                break;
                            }
                        }
                    }
                }

            }

            Console.WriteLine($"\nTotal sum of dummy entries is {grandSum}.\n");
        }


        private List<string> SplitIntoChunks(string text, int chunkSize)
        {
            List<string> chunks = new();
            if (text.Length % chunkSize != 0)
            {
                return chunks;
            }
            for (int i = 0; i < text.Length; i += chunkSize)
            {
                chunks.Add(text.Substring(i, chunkSize));
            }
            return chunks;
        }


        private bool AllChunksMatch(List<string> chunks)
        {
            foreach (var chunk in chunks)
            {
                if (chunk != chunks.First())
                {
                    return false;
                }
            }
            return true;
        }
    }
}

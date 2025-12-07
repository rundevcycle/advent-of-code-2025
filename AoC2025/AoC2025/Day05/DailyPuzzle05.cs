using log4net;

namespace AoC2025.Day05
{
    internal class DailyPuzzle05 : DailyPuzzle
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DailyPuzzle05));

        private List<Tuple<long, long>> _freshRanges = new();
        private List<long> _ingredients = new();


        public DailyPuzzle05(List<string> inputData) : base(inputData) 
        {
            // Split the list into two halves. The first blank line is the divider.
            List<string> firstHalf = new();
            List<string> secondHalf = new();

            bool separatorFound = false;
            foreach (var line in InputData)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    separatorFound = true;
                    continue;
                }
                if (!separatorFound)
                {
                    firstHalf.Add(line);
                }
                else
                {
                    secondHalf.Add(line);
                }
            }

            foreach (var line in firstHalf)
            {
                var range = line.Split("-");
                _freshRanges.Add(new Tuple<long, long>(
                    long.Parse(range[0]), 
                    long.Parse(range[1])
                ));
            }

            foreach (var line in secondHalf)
            {
                _ingredients.Add(long.Parse(line));
            }
        }


        protected override void RunPart1()
        {
            int numFreshIngredients = 0;

            foreach (var ingredient in _ingredients)
            {
                foreach (var range in _freshRanges)
                {
                    if (ingredient >= range.Item1 && ingredient <= range.Item2)
                    {
                        numFreshIngredients++;
                        logger.Debug($"Ingredient {ingredient} is in the fresh range {range.Item1} - {range.Item2}");
                        break;
                    }
                }
            }

            logger.Info($"Found {numFreshIngredients} fresh ingredients.");
        }


        protected override void RunPart2()
        {
            List<long> distinctFreshCodes = new();

            List<Tuple<long, long>> freshCodeRanges = new();

            foreach (var range in _freshRanges.OrderBy(r => r.Item1))
            {
                long first = range.Item1;
                long last = range.Item2;

                logger.Debug($"Checking range {first}-{last}...");

                bool alreadyCovered = false;
                foreach (var otherRange in freshCodeRanges.OrderBy(r => r.Item1))
                {
                    if (alreadyCovered)
                    {
                        break;
                    }

                    // If the first and last fall within another range, skip this one.
                    if (first >= otherRange.Item1 && last <= otherRange.Item2)
                    {
                        alreadyCovered = true;
                        logger.Debug($"    already covered by {otherRange.Item1}-{otherRange.Item2}");
                        continue;
                    }

                    // If the first falls within another range, but the last doesn't, update the first of this range.
                    if (first >= otherRange.Item1 && first <= otherRange.Item2
                        && last > otherRange.Item2)
                    {
                        first = otherRange.Item2 + 1;
                        logger.Debug($"    First is in range {otherRange.Item1}-{otherRange.Item2}.  First is now {first}.");
                    }

                    // If the last falls within another range, but the first doesn't, update the last of the this range.
                    if (last >= otherRange.Item1 && last <= otherRange.Item2 
                        && first < otherRange.Item1)
                    {
                        last = otherRange.Item1 - 1;
                        logger.Debug($"    Last is in range {otherRange.Item1}-{otherRange.Item2}.  Last is now {last}.");
                    }
                }

                // If the last < first, skip it since we already cover that range.
                if (last < first)
                {
                    logger.Debug($"    adjusted range is {first}-{last}.  Not a valid range.");
                    continue;
                }
                else if (!alreadyCovered)
                {
                    logger.Debug($"    adjusted range is {first}-{last}.  Adding the valid range.");
                    freshCodeRanges.Add(new Tuple<long, long>(first, last));
                }
            }

            long numDistinctFreshCodes = 0;
            logger.Debug("Final fresh ingredient ranges:");
            foreach (var range in freshCodeRanges.Distinct().OrderBy(r => r.Item1))
            {
                logger.Debug($"    {range.Item1}-{range.Item2}");
                numDistinctFreshCodes += range.Item2 - range.Item1 + 1;
            }
            logger.Info($"There are {numDistinctFreshCodes} fresh ingredient codes.");
        }
    }
}

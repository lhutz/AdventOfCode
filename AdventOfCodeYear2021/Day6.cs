using System;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 6)]
    public class Day6 : Day<int[]>
    {
        public override int[] ParseInput(string rawInput) => rawInput
            .Split(",", StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

        public override object ExecutePart1()
        {
            return GetAmountOfFishAfterDays(80);
        }

        public override object ExecutePart2()
        {
            return GetAmountOfFishAfterDays(256);
        }

        public long GetAmountOfFishAfterDays(int days)
        {
            var fish = new long[9];
            foreach (var fishGroup in Input.GroupBy(f => f))
            {
                fish[fishGroup.Key] = fishGroup.Count();
            }

            for (var day = 1; day <= days; day++)
            {
                var mommies = fish[0];
                Array.Copy(fish, 1, fish, 0, fish.Length - 1);
                fish[6] += mommies;
                fish[8] = mommies;
            }

            return fish.Sum();
        }
    }
}
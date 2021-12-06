using System;
using System.Collections.Generic;
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

        private object GetAmountOfFishAfterDays(int days)
        {
            return Input
                .Select(_ => new LanternFish(_).DaysPasses(days))
                .Sum(fish => fish.GetAmountOfOffspringPlusMe());
        }
    }

    public class LanternFish
    {
        public int InternalTimer { get; private set; }
        private readonly List<LanternFish> _children;
        public LanternFish()
        {
            InternalTimer = 8;
            _children = new List<LanternFish>();
        }

        public LanternFish(int internalTimer)
        {
            InternalTimer = internalTimer;
            _children = new List<LanternFish>();
        }

        public LanternFish DaysPasses(int days)
        {
            for (int i = 1; i <= days; i++)
            {
                InternalTimer--;
                if (InternalTimer < 0)
                {
                    _children.Add(new LanternFish().DaysPasses(days - i));
                    InternalTimer = 6;
                }
            }

            return this;
        }

        public long GetAmountOfOffspringPlusMe()
        {
            return 1 + _children.Sum(lanternFish => lanternFish.GetAmountOfOffspringPlusMe());
        }

    }
}
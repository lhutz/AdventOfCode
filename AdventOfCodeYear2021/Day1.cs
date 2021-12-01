using System;
using System.Collections.Generic;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 1)]
    public class Day1 : Day.NewLineSplitParsed<int>
    {
        public override object ExecutePart1()
        {
            return AmountWasHigher(Input);
        }

        public override object ExecutePart2()
        {
            var slidingWindows = GetSlidingWindows(Input);
            return AmountWasHigher(slidingWindows);
        }

        private int AmountWasHigher(IEnumerable<int> measurements)
        {
            var wasHigher = 0;
            int? previous = null;
            foreach (var current in measurements)
            {
                if (previous < current) wasHigher++;
                previous = current;
            }

            return wasHigher;
        }

        private IEnumerable<int> GetSlidingWindows(int[] measurements)
        {
            return measurements.Select((measurement, index) =>
                    measurements.Length > index + 2
                    ? measurement + measurements[index + 1] + measurements[index + 2]
                    : -1
                )
                .Where(window => window > -1);
        }
    }
}
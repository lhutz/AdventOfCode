using System;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 7)]
    public class Day7 : Day<int[]>
    {
        public override int[] ParseInput(string rawInput) => rawInput
            .Split(",", StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();

        public override object ExecutePart1()
        {
            return GetCheapest(CalculateFuelCost);
        }

        public override object ExecutePart2()
        {
            return GetCheapest(CalculateFuelCostWithGrowingCost);
        }

        private object GetCheapest(Func<int, int> fuelcostCalculator)
        {
            var cheapest = int.MaxValue;
            for (var i = Input.Min(); i < Input.Max(); i++)
            {
                var fuelCost = fuelcostCalculator(i);
                cheapest = fuelCost < cheapest ? fuelCost : cheapest;
            }

            return cheapest;
        }

        public int CalculateFuelCost(int destinationPosition)
        {
            return Input.Sum(position => Math.Abs(position - destinationPosition));
        }

        public int CalculateFuelCostWithGrowingCost(int destinationPosition)
        {
            return Input.Sum(position =>
            {
                var normalFuel = Math.Abs(position - destinationPosition);
                var totalFuel = 0;
                for (var i = 0; i <= normalFuel; i++)
                {
                    totalFuel += i;
                }
                return totalFuel;
            });
        }
    }
}
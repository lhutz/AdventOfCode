using System;
using System.Collections;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 3)]
    public class Day3 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var gammaRate = "";
            for (int i = 0; i < Input[0].Length; i++)
            {
                gammaRate += GetMostOrLeastCommon(Input, i, true);
            }

            var ypsilonRate = GetOppositeBinaryNumber(gammaRate);
            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(ypsilonRate, 2);
        }

        public override object ExecutePart2()
        {
            var oxygenRating = GetRating(true);
            var co2Rating = GetRating(false);
            return Convert.ToInt32(oxygenRating, 2) * Convert.ToInt32(co2Rating, 2);
        }

        private string GetRating(bool isMostCommon)
        {
            var nthPositition = 0;
            var searchInput = Input;
            while (searchInput.Length > 1)
            {
                var mostOrLeastCommon = GetMostOrLeastCommon(searchInput, nthPositition, isMostCommon);
                searchInput = searchInput.Where(x => x[nthPositition] == mostOrLeastCommon).ToArray();
                nthPositition++;
            }

            return searchInput[0];
        }

        private string GetOppositeBinaryNumber(string gammaRate)
        {
            return new(gammaRate
                .Select(digit => digit == '1' ? '0' : '1')
                .ToArray());
        }

        private char GetMostOrLeastCommon(string[] input, int nthPosition, bool isMost)
        {
            var groupBy = input
                .GroupBy(item => item[nthPosition]);

            var sorting = isMost
                ? groupBy
                    .OrderByDescending(g => g.Count())
                    .ThenByDescending(g => g.Key)
                : groupBy
                    .OrderBy(g => g.Count())
                    .ThenBy(g => g.Key);

            return sorting
                .Select(g => g.Key)
                .First();
        }
    }
}
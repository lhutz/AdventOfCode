using System;
using System.Collections.Generic;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 9)]
    public class Day9 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var lowestPoints = GetLowestPoint(Input);
            return lowestPoints.Sum(_ => _[2] + 1);
        }

        public override object ExecutePart2()
        {
            var lowestPoints = GetLowestPoint(Input);
            var getBasinSizes = GetBasins(Input, lowestPoints);
            return getBasinSizes
                .OrderByDescending(_ => _)
                .Take(3)
                .Aggregate(1, (acc, basinSize) => acc * basinSize);
        }

        private IEnumerable<int> GetBasins(string[] input, int[][] lowestPoints)
        {
            var basins = lowestPoints
                .Select(lowestPoint => FindBasinCoordinates(input, lowestPoint, new List<int[]>()))
                .Select(basinCoordinates => basinCoordinates.OrderBy(_ => _[0])
                    .ThenBy(_ => _[1])
                    .Distinct()
                    .ToList())
                // A basin may include 2 lowest points so a basin may be counted twice.
                .Distinct();
            return basins.Select(_ => _.Count);
        }

        private List<int[]> FindBasinCoordinates(string[] input, int[] coordinates, List<int[]> alreadyFoundCoordinates)
        {
                var xCoordinate = coordinates[0];
                var yCoordinate = coordinates[1];
                GetAdjacentDepths(input, xCoordinate, yCoordinate, input[yCoordinate],
                    out var left, out var right, out var above, out var below);
                var adjacentCoordinates = new[]
                {
                    new[] {xCoordinate - 1, yCoordinate, left},
                    new []{xCoordinate + 1, yCoordinate, right},
                    new []{xCoordinate, yCoordinate - 1, above},
                    new []{xCoordinate, yCoordinate + 1, below}
                };

                alreadyFoundCoordinates.Add(coordinates);
                foreach (var adjacentCoordinate in adjacentCoordinates)
                {
                    var isAlreadyFound = alreadyFoundCoordinates.Any(_ => _[0] == adjacentCoordinate[0] && _[1] == adjacentCoordinate[1]);
                    if(adjacentCoordinate[2] != 9 && !isAlreadyFound)
                        alreadyFoundCoordinates = FindBasinCoordinates(input, adjacentCoordinate, alreadyFoundCoordinates);
                }

                return alreadyFoundCoordinates;
        }

        private int[][] GetLowestPoint(string[] input)
        {
            var coordinates = new List<int[]>();
            for (var yCoordinate = 0; yCoordinate < input.Length; yCoordinate++)
            {
                var currentRow = input[yCoordinate];
                for (var xCoordinate = 0; xCoordinate < currentRow.Length; xCoordinate++)
                {
                    var substring = GetAdjacentDepths(input, xCoordinate, yCoordinate, currentRow, out var left, out var right, out var above, out var below);
                    var current = (int) (xCoordinate == 0 ? char.GetNumericValue(substring[0]) : char.GetNumericValue(substring[1]));

                    if (left > current && right > current && above > current && below > current)
                    {
                        coordinates.Add(new [] {xCoordinate, yCoordinate, current});
                    }
                }
            }

            return coordinates.ToArray();
        }

        private static string GetAdjacentDepths(string[] input,  int xCoordinate, int yCoordinate, string currentRow,
            out int left, out int right, out int above, out int below)
        {
            var rowAbove = yCoordinate == 0 ? "" : input[yCoordinate - 1];
            var rowBelow = yCoordinate == input.Length - 1 ? "" : input[yCoordinate + 1];

            var varSubstringLength = xCoordinate == 0 || xCoordinate == currentRow.Length - 1 ? 2 : 3;
            var startIndex = xCoordinate == 0 ? 0 : xCoordinate - 1;
            var substring = currentRow.Substring(startIndex, varSubstringLength);

            left = (int) (xCoordinate == 0 ? 9 : char.GetNumericValue(substring[0]));
            right = (int) (xCoordinate == currentRow.Length - 1 ? 9 : char.GetNumericValue(substring.Last()));
            above = (int) (rowAbove == "" ? 9 : char.GetNumericValue(rowAbove[xCoordinate]));
            below = (int) (rowBelow == "" ? 9 : char.GetNumericValue(rowBelow[xCoordinate]));
            return substring;
        }
    }
}
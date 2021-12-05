using System;
using System.Collections.Generic;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 5)]
    public class Day5 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var field = new Field(Input, true);
            return field.GetAmountOfDuplicates();
        }

        public override object ExecutePart2()
        {
            var field = new Field(Input, false);
            return field.GetAmountOfDuplicates();
        }
    }

    public class Field
    {
        public List<Coordinate> HydrothermalVentsLocations { get; private set; }

        public Field(string[] lineDescriptions, bool ignoreDiagonal)
        {
            var lines = lineDescriptions
                .Select(descr => descr.Split(" -> ", StringSplitOptions.TrimEntries))
                .Select(coordinatesDescription => new Line(coordinatesDescription[0], coordinatesDescription[1], ignoreDiagonal));
            this.HydrothermalVentsLocations = lines.SelectMany(x => x.Coordinates).ToList();
        }

        public int GetAmountOfDuplicates()
        {
            return HydrothermalVentsLocations
                .GroupBy(x => $"{x.X},{x.Y}")
                .Count(x => x.Count() > 1);
        }
    }

    public class Line
    {
        public List<Coordinate> Coordinates { get; private set; }

        private List<IGetCoordinatesOfLineStrategy> _coordinatesInBetweenStrategies = new()
            {
                new HorizontalStrategy(),
                new VerticalStrategy(),
                new HorizontalRightToLeftStrategy(),
                new VerticalBottomUpStrategy(),
                new DiagonalLeftUpperToRightLower(),
                new DiagonalRightUpperToLeftLower(),
                new DiagonalRightLowerToLeftUpper(),
                new DiagonalLeftLowerToRightUpper()
            };

        public Line(string startCoordinates, string endCoordinates, bool ignoreDiagonal)
        {
            var start = new Coordinate(startCoordinates);
            var end = new Coordinate(endCoordinates);
            this.Coordinates = AddCoordinates(start, end, ignoreDiagonal);
        }

        private List<Coordinate> AddCoordinates(Coordinate start, Coordinate end, bool ignoreDiagonal)
        {
            if (ignoreDiagonal && start.X != end.X && start.Y != end.Y)
            {
                return new List<Coordinate>();
            }

            var coordinates = new List<Coordinate> {start};

            coordinates.AddRange(_coordinatesInBetweenStrategies
                .First(_ => _.Applies(start, end))
                .GetInBetween(start, end));

            coordinates.Add(end);
            return coordinates;
        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Description => $"{X},{Y}";

        public Coordinate(string coordinates)
        {
            var xAndYStart = coordinates.Split(",");
            this.X = int.Parse(xAndYStart[0]);
            this.Y = int.Parse(xAndYStart[1]);
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public interface IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end);
        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end);
    }

    public class DiagonalLeftUpperToRightLower : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.X < end.X && start.Y < end.Y;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            var coordinates = new List<Coordinate>();
            var amountInBetween = end.X - start.X - 1;

            for (int i = 1; i <= amountInBetween; i++)
            {
                coordinates.Add(new Coordinate(start.X + i, start.Y + i));
            }

            return coordinates;
        }
    }

    public class DiagonalRightUpperToLeftLower : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.X > end.X && start.Y < end.Y;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            var coordinates = new List<Coordinate>();
            var amountInBetween = Math.Abs(end.X - start.X) - 1;

            for (int i = 1; i <= amountInBetween; i++)
            {
                coordinates.Add(new Coordinate(start.X - i, start.Y + i));
            }

            return coordinates;
        }
    }

    public class DiagonalRightLowerToLeftUpper : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.X > end.X && start.Y > end.Y;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            return new DiagonalLeftUpperToRightLower().GetInBetween(end, start);
        }
    }

    public class DiagonalLeftLowerToRightUpper : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.X < end.X && start.Y > end.Y;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            return new DiagonalRightUpperToLeftLower().GetInBetween(end, start);
        }
    }

    public class HorizontalStrategy : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.Y == end.Y && start.X < end.X;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            var coordinates = new List<Coordinate>();
            var amountInBetween = end.X - start.X - 1;

            for (int i = 1; i <= amountInBetween; i++)
            {
                coordinates.Add(new Coordinate(start.X + i, start.Y));
            }

            return coordinates;
        }
    }

    public class VerticalStrategy : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.X == end.X && start.Y < end.Y;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            var coordinates = new List<Coordinate>();
            var amountInBetween = end.Y - start.Y - 1;

            for (int i = 1; i <= amountInBetween; i++)
            {
                coordinates.Add(new Coordinate(start.X, start.Y + i));
            }

            return coordinates;
        }
    }

    public class HorizontalRightToLeftStrategy : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.Y == end.Y && start.X > end.X;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            return new HorizontalStrategy().GetInBetween(end, start);
        }
    }

    public class VerticalBottomUpStrategy : IGetCoordinatesOfLineStrategy
    {
        public bool Applies(Coordinate start, Coordinate end)
        {
            return start.X == end.X && start.Y > end.Y;
        }

        public List<Coordinate> GetInBetween(Coordinate start, Coordinate end)
        {
            return new VerticalStrategy().GetInBetween(end, start);
        }
    }
}
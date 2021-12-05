using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day5Test
    {
        private string[] givenExample = {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };

        [Test]
        public void ExecutePart1_GivenExample_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 5;
            var testInstance = new Day5 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturnExpectedValue()
        {
            // Arrange
            var expectedValue = 12;
            var testInstance = new Day5 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenHorizontalStartAndEnd_AllExpectedCoordinates()
        {
            // Arrange
            var start = "0,9";
            var end = "5,9";
            var expectedCoordinates = new List<Coordinate>
            {
                new(0, 9),
                new(1, 9),
                new(2, 9),
                new(3, 9),
                new(4, 9),
                new(5, 9)
            };

            // Act
            var line = new Line(start, end, true);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenVerticalStartAndEnd_AllExpectedCoordinates()
        {
            // Arrange
            var start = "7,0";
            var end = "7,4";
            var expectedCoordinates = new List<Coordinate>
            {
                new(7, 0),
                new(7, 1),
                new(7, 2),
                new(7, 3),
                new(7, 4)
            };

            // Act
            var line = new Line(start, end, true);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenHorizontalStartAndEndRightToLeft_AllExpectedCoordinates()
        {
            // Arrange
            var start = "5,9";
            var end = "0,9";

            var expectedCoordinates = new List<Coordinate>
            {
                new(0, 9),
                new(1, 9),
                new(2, 9),
                new(3, 9),
                new(4, 9),
                new(5, 9)
            };

            // Act
            var line = new Line(start, end, true);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenVerticalStartAndEndBottomUp_AllExpectedCoordinates()
        {
            // Arrange
            var start = "7,4";
            var end = "7,0";
            var expectedCoordinates = new List<Coordinate>
            {
                new(7, 0),
                new(7, 1),
                new(7, 2),
                new(7, 3),
                new(7, 4)
            };

            // Act
            var line = new Line(start, end, true);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenLeftUpperToRightLower_AllExpectedCoordinates()
        {
            // Arrange
            var start = "1,1";
            var end = "6,6";
            var expectedCoordinates = new List<Coordinate>
            {
                new(1,1),
                new(2,2),
                new(3,3),
                new(4,4),
                new(5,5),
                new(6,6),
            };

            // Act
            var line = new Line(start, end, false);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenRighUpperToLeftLower_AllExpectedCoordinates()
        {
            // Arrange
            var start = "6,0";
            var end = "0,6";
            var expectedCoordinates = new List<Coordinate>
            {
                new(6,0),
                new(5,1),
                new(4,2),
                new(3,3),
                new(2,4),
                new(1,5),
                new(0,6),
            };

            // Act
            var line = new Line(start, end, false);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenRightLowerToLeftUpper_AllExpectedCoordinates()
        {
            // Arrange
            var start = "6,6";
            var end = "1,1";
            var expectedCoordinates = new List<Coordinate>
            {
                new(1,1),
                new(2,2),
                new(3,3),
                new(4,4),
                new(5,5),
                new(6,6),
            };

            // Act
            var line = new Line(start, end, false);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_GivenLeftLowerToRightUpper_AllExpectedCoordinates()
        {
            // Arrange
            var start = "0,6";
            var end = "6,0";
            var expectedCoordinates = new List<Coordinate>
            {
                new(6,0),
                new(5,1),
                new(4,2),
                new(3,3),
                new(2,4),
                new(1,5),
                new(0,6),
            };

            // Act
            var line = new Line(start, end, false);

            // Assert
            line.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [Test]
        public void Line_AddCoordinatesInBetween_DiagonalLineButIgnoreDiagonal_AllExpectedCoordinates()
        {
            // Arrange
            var start = "8,0";
            var end = "0,8";

            // Act
            var line = new Line(start, end, true);

            // Assert
            line.Coordinates.Should().BeEmpty();
        }
    }
}
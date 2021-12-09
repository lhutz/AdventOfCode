using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day9Test
    {
        private string[] givenExample =
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678",
        };

        [Test]
        public void ExecutePart1_GivenExample_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 15;
            var testInstance = new Day9 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturnExpectedValue()
        {
            // Arrange
            var expectedValue = 1134;
            var testInstance = new Day9 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
    }
}
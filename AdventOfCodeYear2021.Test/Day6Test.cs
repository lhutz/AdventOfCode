using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day6Test
    {
        private int[] givenExample =
        {
            3,4,3,1,2
        };

        [Test]
        public void ExecutePart1_GivenExample_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 5934;
            var testInstance = new Day6 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturnExpectedValue()
        {
            // Arrange
            var expectedValue = 26984457539;
            var testInstance = new Day6 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
    }
}
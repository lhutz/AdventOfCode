using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day3Test
    {
        [Test]
        public void ExecutePart1_GivenExample_ShouldReturn198()
        {
            // Arrange
            var givenExample = new []
            {
                "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"
            };
            var expectedValue = 198;
            var testInstance = new Day3 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturn230()
        {
            // Arrange
            var givenExample = new []
            {
                "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"
            };
            var expectedValue = 230;
            var testInstance = new Day3 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
    }
}
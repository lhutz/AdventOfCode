using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day2Test
    {
        [Test]
        public void ExecutePart1_GivenExample_ShouldReturn150()
        {// Arrange
            var givenExample = new [] {  "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"};
            var expectedValue = 150;
            var testInstance = new Day2 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturn900()
        {// Arrange
            var givenExample = new [] {  "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"};
            var expectedValue = 900;
            var testInstance = new Day2 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
    }
}
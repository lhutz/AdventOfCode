using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day1Test
    {
        [Test]
        public void ExecutePart1_GivenExample_ShouldReturn7()
        {
            // Arrange
            var givenExample = new [] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var expectedValue = 7;
            var testInstance = new Day1 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
        [Test]
        public void ExecutePart2_GivenExample_ShouldReturn5()
        {
            // Arrange
            var givenExample = new [] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var expectedValue = 5;
            var testInstance = new Day1 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
    }
}
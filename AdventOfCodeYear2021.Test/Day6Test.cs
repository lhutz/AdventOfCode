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
        public void GetAmountOfFishAfterDays_GivenExample10Days_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 12;
            var testInstance = new Day6 {Input = givenExample};

            // Act
            var receivedValue = testInstance.GetAmountOfFishAfterDays(10);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetAmountOfFishAfterDays_GivenExample15Days_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 20;
            var testInstance = new Day6 {Input = givenExample};

            // Act
            var receivedValue = testInstance.GetAmountOfFishAfterDays(15);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
            public void GetAmountOfFishAfterDays_GivenExample20Days_ShouldReturnExpected()
            {
                // Arrange
                var expectedValue = 34;
                var testInstance = new Day6 {Input = givenExample};

                // Act
                var receivedValue = testInstance.GetAmountOfFishAfterDays(20);

                // Assert
                receivedValue.Should().Be(expectedValue);
        }

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
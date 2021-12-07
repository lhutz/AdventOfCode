using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day7Test
    {
        private int[] givenExample =
        {
            16,14,2,0,4,2,7,1,2,1
        };

        [Test]
        public void ExecutePart1_GivenExample_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 37;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturnExpectedValue()
        {
            // Arrange
            var expectedValue = 168;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCost_2_37()
        {
            // Arrange
            var destination = 2;
            var expectedValue = 37;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.CalculateFuelCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCost_1_41()
        {
            // Arrange
            var destination = 1;
            var expectedValue = 41;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.CalculateFuelCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCost_3_39()
        {
            // Arrange
            var destination = 3;
            var expectedValue = 39;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.CalculateFuelCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCost_10_71()
        {
            // Arrange
            var destination = 3;
            var expectedValue = 39;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.CalculateFuelCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
        

        [Test]
        public void CalculateFuelCostWithGrowingCost_2_206()
        {
            // Arrange
            var destination = 2;
            var expectedValue = 206;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.CalculateFuelCostWithGrowingCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCostWithGrowingCost_5_168()
        {
            // Arrange
            var destination = 5;
            var expectedValue = 168;
            var testInstance = new Day7 {Input = givenExample};

            // Act
            var receivedValue = testInstance.CalculateFuelCostWithGrowingCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCostWithGrowingCost_1_1()
        {
            // Arrange
            var destination = 1;
            var expectedValue = 1;
            var testInstance = new Day7 {Input = new [] {0}};

            // Act
            var receivedValue = testInstance.CalculateFuelCostWithGrowingCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCostWithGrowingCost_2_3()
        {
            // Arrange
            var destination = 2;
            var expectedValue = 3;
            var testInstance = new Day7 {Input = new [] {0}};

            // Act
            var receivedValue = testInstance.CalculateFuelCostWithGrowingCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void CalculateFuelCostWithGrowingCost_3_6()
        {
            // Arrange
            var destination = 3;
            var expectedValue = 6;
            var testInstance = new Day7 {Input = new [] {0}};

            // Act
            var receivedValue = testInstance.CalculateFuelCostWithGrowingCost(destination);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

    }
}
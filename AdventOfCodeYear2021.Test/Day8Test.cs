using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCodeYear2021.Test
{
    [TestFixture]
    public class Day8Test
    {
        private string[][][] givenExample =
        {
            new [] {new [] {"be", "cfbegad", "cbdgef", "fgaecd", "cgeb","fdcge","agebfd","fecdb","fabcd","edb"}, new [] {"fdgacbe", "cefdb","cefbgd","gcbe"}},
            new [] {new [] {"edbfga", "begcd", "cbg", "gc", "gcadebf","fbgde","acbgfd","abcde","gfcbed","gfec"}, new [] {"fcgedb", "cgb","dgebacf","gc"}},
            new [] {new [] {"fgaebd", "cg", "bdaec", "gdafb", "agbcfd","gdcbef","bgcad","gfac","gcb","cdgabef"}, new [] {"cg", "cg","fdcagb","cbg"}},
            new [] {new [] {"fbegcd", "cbd", "adcefb", "dageb", "afcb","bc","aefdc","ecdab","fgdeca","fcdbega"}, new [] {"efabcd", "cedba","gadfec","cb"}},
            new [] {new [] {"aecbfdg", "fbg", "gf", "bafeg", "dbefa","fcge","gcbea","fcaegb","dgceab","fcbdga"}, new [] {"gecf", "egdcabf","bgf","bfgea"}},
            new [] {new [] {"fgeab", "ca", "afcebg", "bdacfeg", "cfaedg","gcfdb","baec","bfadeg","bafgc","acf"}, new [] {"gebdcfa", "ecba","ca","fadegcb"}},
            new [] {new [] {"dbcfg", "fgd", "bdegcaf", "fgec", "aegbdf","ecdfab","fbedc","dacgb","gdcebf","gf"}, new [] {"cefg", "dcbef","fcge","gbcadfe"}},
            new [] {new [] {"bdfegc", "cbegaf", "gecbf", "dfcage", "bdacg","ed","bedf","ced","adcbefg","gebcd"}, new [] {"ed", "bcgafe","cdgba","cbgef"}},
            new [] {new [] {"egadfb", "cdbfeg", "cegd", "fecab", "cgb","gbdefca","cg","fgcdab","egfdb","bfceg"}, new [] {"gbdfcae", "bgc","cg","cgb"}},
            new [] {new [] {"gcafb", "gcf", "dcaebfg", "ecagb", "gf","abcdeg","gaef","cafbge","fdbac","fegbdc"}, new [] {"fgae", "cfgab","fg","bagce"}},
        };

        [Test]
        public void ExecutePart1_GivenExample_ShouldReturnExpected()
        {
            // Arrange
            var expectedValue = 26;
            var testInstance = new Day8 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart1();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void ExecutePart2_GivenExample_ShouldReturnExpectedValue()
        {
            // Arrange
            var expectedValue = 61229;
            var testInstance = new Day8 {Input = givenExample};

            // Act
            var receivedValue = testInstance.ExecutePart2();

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_InputExample_5353()
        {
            // Arrange
            var line = new []
            {
                new [] {"acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb","ab"},
                new [] {"cdfeb", "fcadb", "cdfeb", "cdbaf"}
            };
            var expectedValue = 5353;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetCode_InputExample_CorrectCode()
        {
            // Arrange
            var line = new []
            {
                new [] {"acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb","ab"},
                new [] {"cdfeb fcadb cdfeb cdbaf"}
            };
            var expectedValue = new [] { "cagedb", "ab", "gcdfa", "fbcad", "eafb", "cdfbe", "cdfgeb", "dab", "acedgfb", "cefabd" };

            // Act
            var receivedValue = new Day8().GetCode(line[0]);

            // Assert
            receivedValue.Should().ContainInOrder(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input0_8394()
        {
            // Arrange
            var line = givenExample[0];
            var expectedValue = 8394;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input1_9781()
        {
            // Arrange
            var line = givenExample[1];
            var expectedValue = 9781;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input2_1197()
        {
            // Arrange
            var line = givenExample[2];
            var expectedValue = 1197;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input3_9361()
        {
            // Arrange
            var line = givenExample[3];
            var expectedValue = 9361;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input4_4873()
        {
            // Arrange
            var line = givenExample[4];
            var expectedValue = 4873;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input5_8418()
        {
            // Arrange
            var line = givenExample[5];
            var expectedValue = 8418;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input6_4548()
        {
            // Arrange
            var line = givenExample[6];
            var expectedValue = 4548;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input7_1625()
        {
            // Arrange
            var line = givenExample[7];
            var expectedValue = 1625;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input8_8717()
        {
            // Arrange
            var line = givenExample[8];
            var expectedValue = 8717;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }

        [Test]
        public void GetOutputValue_Input9_4315()
        {
            // Arrange
            var line = givenExample[9];
            var expectedValue = 4315;

            // Act
            var receivedValue = new Day8().GetOutputValue(line);

            // Assert
            receivedValue.Should().Be(expectedValue);
        }
    }
}
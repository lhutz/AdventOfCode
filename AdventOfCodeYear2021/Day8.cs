using System;
using System.Collections.Generic;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 8)]
    public class Day8 : Day<string[][][]>
    {
        public override string[][][] ParseInput(string rawInput)
        {
            return rawInput.Split('\n')
                .Select(_ =>
                {
                    var inputAndOutput = _.Split(" | ", StringSplitOptions.TrimEntries);
                    var input = inputAndOutput[0].Split(" ", StringSplitOptions.TrimEntries);
                    var output = inputAndOutput[1].Split(" ", StringSplitOptions.TrimEntries);
                    return new[] {input, output};
                }).ToArray();
        }

        public override object ExecutePart1()
        {
            var lengthOfUniqueSegments = new[] {2, 4, 3, 7};
            return Input
                .Sum(inputLine => inputLine[1]
                    .Count(output => lengthOfUniqueSegments.Contains(output.Length)));
        }

        public override object ExecutePart2()
        {
            return Input.Sum(GetOutputValue);
        }

        public int GetOutputValue(string[][] line)
        {
            var code = this.GetCode(line[0]).ToList();
            var decrypted = "";
            for (var i = 0; i < line[1].Length; i++)
                decrypted += Decrypt(code, line[1][i]);

            return int.Parse(decrypted);
        }

        private string Decrypt(List<string> code, string value)
        {
            return code.IndexOf(code.First(_ => new HashSet<char>(_).SetEquals(value))).ToString();
        }

        public string[] GetCode(string[] input)
        {
            var oneValue = input.First(_ => _.Length == 2);
            var fourValue = input.First(_ => _.Length == 4);
            var sevenValue = input.First(_ => _.Length == 3);
            var eighthValue = input.First(_ => _.Length == 7);

            var twoThreeFiveValue = input.Where(_ => _.Length == 5).ToArray();
            var sixNineZeroValue = input.Where(_ => _.Length == 6).ToArray();

            var threeValue = twoThreeFiveValue.First(three => oneValue.All(three.Contains));
            var nineValue = sixNineZeroValue.First(nine => fourValue.All(nine.Contains));
            var zeroValue = sixNineZeroValue.First(zero => oneValue.All(zero.Contains) && zero != nineValue);
            var sixValue = sixNineZeroValue.First(six => !new [] {nineValue, zeroValue}.Contains(six));
            var fiveValue = twoThreeFiveValue.First(five => five.All(sixValue.Contains));
            var twoValue = twoThreeFiveValue.First(two => !new [] {threeValue, fiveValue}.Contains(two));
            return new[]
            {
                zeroValue, oneValue, twoValue, threeValue, fourValue,
                fiveValue, sixValue, sevenValue, eighthValue, nineValue
            };
        }
    }
}
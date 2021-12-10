using System;
using System.Collections.Generic;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 10)]
    public class Day10 : Day.NewLineSplitParsed<string>
    {
        private readonly Dictionary<char, int> _scoring1 = new()
        {
            {')', 3},
            {']', 57},
            {'}', 1197},
            {'>', 25137}
        };

        private readonly Dictionary<char, int> _scoring2 = new()
        {
            {')', 1},
            {']', 2 },
            {'}', 3 },
            {'>', 4 }
        };


        private readonly Dictionary<char, char> _matchingCharacter = new()
        {
            {')', '('},
            {']', '['},
            {'}', '{'},
            {'>', '<'}
        };

        private string[] matches = {"()", "[]", "{}", "<>"};

        public override object ExecutePart1()
        {
            return Input.Select(RemoveMatches).Select(GetScore1).Sum();
        }

        public override object ExecutePart2()
        {
            var linesWithRemovedMatches = Input.Select(RemoveMatches);
            var notCorrupted = linesWithRemovedMatches.Where(_ => GetScore1(_) == 0);
            var fixes = notCorrupted.Select(GetFix);
            var scores = fixes.Select(GetScore2);
            var orderedScores = scores.OrderBy(_ => _).ToArray();
            var middleScore = orderedScores[orderedScores.Length / 2];

            return middleScore;
        }

        private long GetScore2(string fix)
        {
            long score = 0;
            foreach (var c in fix)
            {
                score *= 5;
                score += _scoring2[c];
            }

            return score;
        }

        private string GetFix(string line)
        {
            var fix = "";
            for (var i = line.Length - 1; i >= 0; i--)
            {
                var c = line[i];
                fix += _matchingCharacter.FirstOrDefault(x => x.Value == c).Key;
            }

            return fix;
        }

        private int GetScore1(string removed)
        {
            var brokenChar = removed.FirstOrDefault(_ => _matchingCharacter.ContainsKey(_), '0');
            return brokenChar != '0' ? _scoring1[brokenChar] : 0;
        }

        private string RemoveMatches(string line)
        {
            while (matches.Any(line.Contains))
            {
                line = matches.Aggregate(line, (accLine, match) => accLine.Replace(match, ""));
            }

            return line;
        }
    }
}
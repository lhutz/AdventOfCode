using System;
using System.Collections.Generic;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 4)]
    public class Day4 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var drawnNumbers = GetDrawnNumbers(Input);
            var inputBingoCards = GetBingoCards(Input);
            var winningBingoCard = GetWinningBingoCard(drawnNumbers, inputBingoCards);

            return winningBingoCard.GetScore();
        }

        public override object ExecutePart2()
        {
            var drawnNumbers = GetDrawnNumbers(Input);
            var inputBingoCards = GetBingoCards(Input);
            BingoCard? winningBingoCard = null;
            var amountOfBingoCards = inputBingoCards.Count;
            for (var i = 0; i < amountOfBingoCards; i++)
            {
                winningBingoCard = GetWinningBingoCard(drawnNumbers, inputBingoCards);
                inputBingoCards.Remove(winningBingoCard);
            }

            return winningBingoCard.GetScore();

        }

        private List<int> GetDrawnNumbers(string[] input)
        {
            return input[0].Split(",").Select(int.Parse).ToList();
        }

        private List<BingoCard> GetBingoCards(string[] input)
        {
            var bingoCards = new List<BingoCard>();

            var bingoCardInputs = input.Skip(2).Take(input.Length - 2).ToArray();
            for (var i = 0; i < bingoCardInputs.Length; i += 6)
            {
                var bingoCardInput = bingoCardInputs.Skip(i).Take(5).ToArray();
                bingoCards.Add(new BingoCard(bingoCardInput));
            }

            return bingoCards;
        }

        private BingoCard GetWinningBingoCard(List<int>? drawnNumbers, List<BingoCard>? inputBingoCards)
        {
            BingoCard? winningBingoCard = null;
            foreach (var drawnNumber in drawnNumbers)
            {
                winningBingoCard = inputBingoCards.FirstOrDefault(x => x.AddAndCheckForBingo(drawnNumber));
                if (winningBingoCard != null)
                {
                    break;
                }
            }

            return winningBingoCard;
        }
    }

    public class BingoCard
    {
        private List<List<int>> rows;
        private List<List<int>> collumns;
        private List<int> drawnNumbers;

        public BingoCard(string[] givenRows)
        {
            collumns = new List<List<int>>();
            rows = new List<List<int>>();
            this.drawnNumbers = new List<int>();

            foreach (var givenRow in givenRows)
            {
                var seperateNumbers = givenRow.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                rows.Add(seperateNumbers.Select(int.Parse).ToList());
                if (collumns.Count == 0)
                {
                    foreach (var seperateNumber in seperateNumbers)
                    {
                        collumns.Add(new List<int>{int.Parse(seperateNumber)});
                    }
                }
                else
                {
                    for (var i = 0; i < seperateNumbers.Length; i++)
                    {
                        collumns[i].Add(int.Parse(seperateNumbers[i]));
                    }
                }
            }
        }

        public bool AddAndCheckForBingo(int drawnNumber)
        {
            this.drawnNumbers.Add(drawnNumber);
            return rows.Any(FullyDrawn) || collumns.Any(FullyDrawn);
        }

        public int GetScore()
        {
            var allNumbers = rows.SelectMany(x => x);
            var unmarkedNumbers = allNumbers.Except(drawnNumbers);
            return unmarkedNumbers.Aggregate(0, (acc, value) => acc += value ) * drawnNumbers.Last();
        }

        private bool FullyDrawn(List<int> numbers)
        {
            return numbers.All(drawnNumbers.Contains);
        }
    }
}
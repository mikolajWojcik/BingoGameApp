using System;
using System.Collections.Generic;
using System.Linq;

namespace BingoGameApp
{
    public class BingoGame
    {
        private readonly bool _firstWins;
        private int _currentRound = 0;
        public IEnumerable<int> RoundsNumbers { get; }

        public List<Board> Boards { get; } = new();

        public BingoGame(IEnumerable<int> roundsNumbers, bool firstWins = true)
        {
            _firstWins = firstWins;
            RoundsNumbers = roundsNumbers;
        }

        public void AddBoard(List<int> boardNumbers)
        {
            if (boardNumbers.Count != Board.BoardSize * Board.BoardSize)
                throw new ArgumentException("To little numbers for board");

            var board = new Board(boardNumbers);
            Boards.Add(board);
        }

        public int PlayGame()
        {
            foreach (var number in RoundsNumbers)
            {
                foreach (var board in Boards)
                {
                    board.SelectNumber(number);
                    if (_firstWins && board.CheckIfWon())
                    {
                        Console.WriteLine($"Last number is {number}");
                        return board.CalculateScore(number);
                    }
                }

                if (!_firstWins)
                {
                    if (Boards.Count == 1 && Boards.First().CheckIfWon())
                    {
                        return Boards.First().CalculateScore(number);
                    }
                    
                    var boardsToRemove = Boards.Where(x => x.CheckIfWon()).ToList();
                    foreach (var board in boardsToRemove)
                    {
                        Boards.Remove(board);
                    }
                }
            }

            return 0;
        }
    }
}
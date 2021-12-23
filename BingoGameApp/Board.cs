using System;
using System.Collections.Generic;
using System.Linq;

namespace BingoGameApp
{
    public class Board
    {
        public static int BoardSize = 5;
        private List<List<BoardItem>> _board = new();

        public Board(List<int> boardNumbers)
        {
            var row = new List<BoardItem>();

            for (int i = 0; i < boardNumbers.Count; i++)
            {
                if (i % BoardSize == 0 && row.Count == BoardSize)
                {
                    _board.Add(row);
                    row = new List<BoardItem>();
                }

                row.Add(new BoardItem(boardNumbers[i]));
            }
            
            _board.Add(row);
        }

        public bool SelectNumber(int number)
        {
            foreach (var row in _board)
            {
                foreach (var item in row)
                {
                    if (item.Number == number)
                    {
                        item.IsSelected = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckIfWon()
        {
            foreach (var row in _board)
            {
                if (row.All(x => x.IsSelected))
                {
                    return true;
                }
            }

            for (int i = 0; i < BoardSize; i++)
            {
                var column = GetColumn(i).ToList();
                if (column.All(x => x.IsSelected))
                {
                    return true;
                }
            }

            return false;
        }

        public int CalculateScore(int lastNumber)
        {
            var result = _board.Select(row => row.Where(x => !x.IsSelected).Sum(y => y.Number)).Sum();
            return result * lastNumber;
        }

        private IEnumerable<BoardItem> GetColumn(int i)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                yield return _board[j][i];
            }
        }
    }

    public class BoardItem
    {
        public bool IsSelected { get; set; }
        public int Number { get; }

        public BoardItem(int number)
        {
            Number = number;
        }
    }
}
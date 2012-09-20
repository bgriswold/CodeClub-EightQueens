using System;
using System.Collections.Generic;
using System.Linq;

namespace EightQueens
{
    public class EightQueensSolver
    {
        private const int Queen = 2;
        private const int NotQueen = 1;
        private const int Unknown = 0;

        private int _cellCount;
        
        public List<GridCell> Solve(List<GridCell> puzzle)
        {
            _cellCount = puzzle.Count;
        
            return Solve(puzzle, 0);
        }

        private int GetNextCellWithUnknownValue(List<GridCell> puzzle, int index)
        {
            for (int i = index; i < _cellCount; i++)
            {
                if (puzzle[i].Value == 0)
                {
                    return i;
                }
            }

            return -1;
        }
        private List<GridCell> Solve(List<GridCell> puzzle, int index)
        {
            index = GetNextCellWithUnknownValue(puzzle, index);

            if (index == -1)
            {
                // We reached the end of the grid and all entries are valid. The end.
                return puzzle; 
            }
            
            // Set queen and non-queen values for current grid cell. 
            // If either move is valid, continue to solve using this additional value.
            for (int i = Queen; i >= NotQueen; i--)
            {
                puzzle[index].Value = i;

                if (IsValidMove(puzzle, puzzle[index]) && Solve(puzzle, index) != null)
                {
                    return puzzle;
                }
            }

            // If queen or non-queen values were not valid, reset value to unknown 
            // and return null which tells the routine to back out.
            puzzle[index].Value = Unknown;
            return null;
        }
        
        public bool IsValidMove(List<GridCell> puzzle, GridCell gridCell)
        {
            var max = (int) Math.Sqrt(puzzle.Count);
           
            if (gridCell.Value == Queen && QueenAlreadyOnRow(puzzle, gridCell))
            {
                return false;
            }
             
            if (gridCell.Value == NotQueen && TooManyNotQueensOnRow(puzzle, gridCell, max))
            {
                return false;
            }

            if (gridCell.Value == Queen && QueenAlreadyInColumn(puzzle, gridCell))
            {
                return false;
            }

            if (gridCell.Value == NotQueen && TooManyNotQueensInColumn(puzzle, gridCell, max))
            {
                return false;
            }


            // Diagonal check
            if (gridCell.Value == Queen)
            {
                // move up left
                var r = gridCell.Row - 1;
                var c = gridCell.Column - 1;

                while(r > 0 && c > 0)
                {
                    if (puzzle.First(x => x.Row == r && x.Column == c).Value == Queen)
                        return false;

                    --r; --c;
                }

                // move down right
                r = gridCell.Row + 1;
                c = gridCell.Column + 1;

                while (r <= max && c <= max)
                {
                    if (puzzle.First(x => x.Row == r && x.Column == c).Value == Queen)
                        return false;

                    ++r; ++c;
                }

                // move up right
                r = gridCell.Row - 1;
                c = gridCell.Column + 1;

                while (r > 0 && c <= max)
                {
                    if (puzzle.First(x => x.Row == r && x.Column == c).Value == Queen)
                        return false;

                    --r; ++c;
                }

                // move down left
                r = gridCell.Row + 1;
                c = gridCell.Column - 1;

                while (r <= max && c > 0)
                {
                    if (puzzle.First(x => x.Row == r && x.Column == c).Value == Queen)
                        return false;

                    ++r; --c;
                }
            }
            else
            {
                // move up left
                var r = gridCell.Row - 1;
                var c = gridCell.Column - 1;
                var count = 0;

                while(r > 0 && c > 0)
                {
                    var ce = puzzle.First(x => x.Row == r && x.Column == c);
                    if (ce.Value == NotQueen)
                    {
                        ++count;
                    }

                    --r; --c;
                }

                // move down right
                r = gridCell.Row + 1;
                c = gridCell.Column + 1;

                while (r <= max && c <= max)
                {
                    var ce = puzzle.First(x => x.Row == r && x.Column == c);
                    if (ce.Value == NotQueen)
                    {
                        ++count;
                    }
                    
                    ++r; ++c;
                }

                if (count > max) return false;

                count = 0;

                // move up right
                r = gridCell.Row - 1;
                c = gridCell.Column + 1;

                while (r > 0 && c <= max)
                {
                    var ce = puzzle.First(x => x.Row == r && x.Column == c);
                    if (ce.Value == NotQueen)
                    {
                        ++count;
                    }
                    

                    --r; ++c;
                }

                // move down left
                r = gridCell.Row + 1;
                c = gridCell.Column - 1;

                while (r <= max && c > 0)
                {
                    var ce = puzzle.First(x => x.Row == r && x.Column == c);
                    if (ce.Value == NotQueen)
                    {
                        ++count;
                    }
                    
                    ++r; --c;
                }


                if (count > max) return false;
            }
            return true;
        }

        private static bool QueenAlreadyOnRow(IEnumerable<GridCell> puzzle, GridCell gridCell)
        {
            return puzzle.Count(x => x.Row == gridCell.Row && x.Value == Queen) > 1;
        }

        private static bool TooManyNotQueensOnRow(IEnumerable<GridCell> puzzle, GridCell gridCell, int nonQueensAllowed)
        {
            return puzzle.Count(x => x.Row == gridCell.Row && x.Value == NotQueen) >= nonQueensAllowed;
        }

        private static bool QueenAlreadyInColumn(IEnumerable<GridCell> puzzle, GridCell gridCell)
        {
            return puzzle.Count(x => x.Column == gridCell.Column && x.Value == Queen) > 1;
        }

        private static bool TooManyNotQueensInColumn(IEnumerable<GridCell> puzzle, GridCell gridCell, int nonQueensAllowed)
        {
            return puzzle.Count(x => x.Column == gridCell.Column && x.Value == NotQueen) >= nonQueensAllowed;
        }

    }
}
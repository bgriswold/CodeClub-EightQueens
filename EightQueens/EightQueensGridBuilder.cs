using System.Collections.Generic;

namespace EightQueens
{
    public static class EightQueensGridBuilder
    {
        public static List<GridCell> Build(int dimension)
        {
            var grid = new List<GridCell>();

            for (int j = 1; j <= dimension; j++)
            {
                for (int k = 1; k <= dimension; k++)
                {
                    grid.Add(new GridCell { Row = j, Column = k, Value = 0 });
                }
            }

            return grid;
        }
    }
}
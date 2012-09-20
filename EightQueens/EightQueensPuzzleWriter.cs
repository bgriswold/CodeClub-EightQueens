using System;
using System.Collections.Generic;
using System.Linq;

namespace EightQueens
{
    public class EightQueensPuzzleWriter
    {
        public static void WriteToConsole(List<GridCell> puzzle)
        {
            var max = Math.Sqrt(puzzle.Count);

            for (int j = 1; j <= max; j++)
            {
                // Write out each row
                puzzle
                    .Where(x => x.Row == j)
                    .OrderBy(x => x.Column)
                    .Select(x => x.Value)
                    .ToList()
                    .ForEach(Console.Write);
                
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
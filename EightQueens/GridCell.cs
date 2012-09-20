using System;

namespace EightQueens
{
    public class GridCell
    {
        public int Row { get; set; }
        public int Column { get; set; }

        // Queen = 2; NotQueen = 1; Unknown = 0;
        // Silly, right? Should have used Nullable<bool>.
        // But the code looks really gross with so many HasValue checks!
        public int Value { get; set; }
    }
}
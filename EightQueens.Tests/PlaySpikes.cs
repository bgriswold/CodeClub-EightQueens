using NUnit.Framework;

namespace EightQueens.Tests
{
    [TestFixture]
    public class PlaySpikes
    {
        [Test]
        public void EightQueens()
        {
            var puzzle = EightQueensGridBuilder.Build(16);
            new EightQueensSolver().Solve(puzzle);
            EightQueensPuzzleWriter.WriteToConsole(puzzle);
        }
    }
}

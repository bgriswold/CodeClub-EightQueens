using NUnit.Framework;

namespace EightQueens.Tests
{
    [TestFixture]
    public class PlaySpikes
    {
        [Test]
        public void EightQueens()
        {
            Play(8);
        }

        [Test]
        public void SixQueens()
        {
            Play(6);
        }

        private static void Play(int dimension)
        {
            var puzzle = EightQueensGridBuilder.Build(dimension);
            new EightQueensSolver().Solve(puzzle);
            EightQueensPuzzleWriter.WriteToConsole(puzzle);
        }
    }
}

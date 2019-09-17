using System.Linq;
using MattEland.Starship.Logic;
using NUnit.Framework;

namespace Tests
{
    public class RepositoryTests
    {
        [Test]
        public void RepositoryShouldStartWithGameState()
        {
            // Arrange
            var repository = new GameRepository();

            // Act
            var games = repository.Games;

            // Assert
            Assert.Greater(games.Count(), 0);
        }
    }
}
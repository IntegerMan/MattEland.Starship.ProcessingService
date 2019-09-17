using MattEland.Starship.Logic;
using MattEland.Starship.ProcessingService.Controllers;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            var controller = new GamesController();

            // Act
            var result = controller.NewGame();

            // Assert
            Assert.IsNotNull(result);
            GameState state = (GameState) result.Value;
            Assert.AreEqual(2, state.Id);
        }
    }
}
using System.Linq;
using MattEland.Starship.Logic.Models;
using MattEland.Starship.ProcessingService.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;

namespace MattEland.Starship.Tests
{
    public class GamesControllerTests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            var controller = new GamesController();

            // Act
            var result = controller.NewGame();

            // Assert
            var state = GetGameState(result);
            Assert.AreEqual(2, state.Id);
        }

        private static GameState GetGameState(ObjectResult result)
        {
            Assert.IsNotNull(result);
            GameState state = (GameState) result.Value;
            return state;
        }

        [Test]
        public void SimulatingFirstTurnShouldResultInCrewMemberSelfAssigningTicket()
        {
            // Arrange
            var controller = new GamesController();
            var game = GetGameState(controller.NewGame());

            // Act
            var result = controller.ProcessGameMove(game.Id, game);

            // Assert
            GameState newState = GetGameState((ObjectResult) result.Result);
            var workItem = newState.WorkItems.First();
            workItem.Status.ShouldBe(WorkItemStatus.ReadyForWork);
            workItem.AssignedCrewId.ShouldNotBeNull();
        }
    }
}
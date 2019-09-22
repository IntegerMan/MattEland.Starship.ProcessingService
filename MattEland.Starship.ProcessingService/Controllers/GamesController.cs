using System.Collections.Generic;
using MattEland.Starship.Logic;
using MattEland.Starship.Logic.Models;
using MattEland.Starship.Logic.Simulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MattEland.Starship.ProcessingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameRepository _repository = new GameRepository();
        private readonly GameSimulator _simulator = new GameSimulator();

        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<GameState>> LoadGame()
        {
            return Ok(_repository.Games);
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public ActionResult<GameState> LoadGame(int id)
        {
            var game = _repository.GetGame(id);

            if (game != null)
            {
                return Ok(game);
            }

            return new NotFoundResult();
        }

        // PUT api/games/5
        [HttpPut("{id}")]
        public ActionResult<GameState> ProcessGameMove(int id, [FromBody] GameState gameState)
        {
            // Validate the input
            if (gameState == null)
            {
                return new BadRequestObjectResult(ModelState);
            }
            if (gameState.Id != id)
            {
                return new BadRequestObjectResult("The game ID did not match the game ID specified in the game state");
            }

            // Simulate the turn
            var newState = _simulator.SimulateTurn(gameState);

            // Save the new state
            _repository.UpdateState(newState);

            // Return the new state
            return Ok(newState);
        }

        // POST api/games
        [HttpPost]
        public CreatedResult NewGame()
        {
            var game = _repository.CreateNewGame();

            return new CreatedResult($"/api/games/{game.Id}", game);
        }

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            bool deleted = _repository.DeleteGame(id);

            if (deleted)
            {
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }

            return new NotFoundResult();
        }
    }
}

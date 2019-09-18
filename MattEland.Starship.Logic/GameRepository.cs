using System.Collections.Generic;
using System.Linq;
using MattEland.Starship.Logic.Models;
using MattEland.Starship.Logic.Simulation;

namespace MattEland.Starship.Logic
{
    public class GameRepository
    {
        private readonly GameSimulator _simulator = new GameSimulator();
        private readonly IList<GameState> _games = new List<GameState>();

        public GameRepository()
        {
            // Start with some sample data
            CreateNewGame();
        }

        public IEnumerable<GameState> Games => _games;

        public GameState GetGame(int id) => _games.FirstOrDefault(g => g.Id == id);

        public GameState CreateNewGame()
        {
            int id = _games.Count + 1;
            var game = _simulator.BuildNewGameState(id);
            _games.Add(game);

            return game;
        }

        public bool DeleteGame(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);

            return game != null && _games.Remove(game);
        }
    }
}
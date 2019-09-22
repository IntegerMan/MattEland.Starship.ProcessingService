using System.Collections.Generic;
using MattEland.Starship.Logic.Models;
using MattEland.Starship.Logic.Simulation;

namespace MattEland.Starship.Logic
{
    public class GameRepository
    {
        private readonly GameSimulator _simulator = new GameSimulator();
        private readonly IDictionary<int, GameState> _games = new Dictionary<int, GameState>();

        public GameRepository()
        {
            // Start with some sample data
            CreateNewGame();
        }

        public IEnumerable<GameState> Games => _games.Values;

        public GameState GetGame(int id)
        {
            _games.TryGetValue(id, out var game);
            return game;
        }

        public GameState CreateNewGame()
        {
            int id = _games.Count + 1;
            var options = new NewGameOptions(1, 2, 1);
            var game = _simulator.BuildNewGameState(id, options);
            _games[id] = game;

            return game;
        }

        public bool DeleteGame(int id) => _games.Remove(id);

        public void UpdateState(GameState newState) => _games[newState.Id] = newState;
    }
}
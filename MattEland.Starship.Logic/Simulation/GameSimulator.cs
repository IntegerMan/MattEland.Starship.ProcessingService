using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation
{
    public class GameSimulator
    {
        public GameState BuildNewGameState(int id)
        {
            var state = new GameState(id);
            state.Time = new GameTime(8, 4, 2422, 3, 20);

            state.GenerateCrewMembers(2)
                 .GenerateSystems(5)
                 .GenerateWorkItems(2);

            return state;
        }
    }
}
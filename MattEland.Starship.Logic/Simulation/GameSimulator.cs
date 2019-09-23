using MattEland.Starship.Logic.Models;
using MattEland.Starship.Logic.Simulation.Behaviors;

namespace MattEland.Starship.Logic.Simulation
{
    public class GameSimulator
    {
        private readonly CrewBehaviorTree _actorBehaviorTree = new CrewBehaviorTree();

        public GameState BuildNewGameState(int id, NewGameOptions options)
        {
            var state = new GameState(id);
            state.Time = new GameTime(8, 4, 2422, 3, 20);

            state.GenerateCrewMembers(options.StartingCrewMembers)
                 .GenerateSystems(options.StartingSystems)
                 .GenerateWorkItems(options.StartingWorkItems);

            return state;
        }

        public GameState SimulateTurn(GameState gameState)
        {
            // Simulate each actor's actions
            foreach (var actor in gameState.Crew)
            {
                var context = new CrewContext(actor, gameState);

                var result = _actorBehaviorTree.Evaluate(context);
                if (result?.SelectedNode != null)
                {
                    break;
                }
            }

            // Advance Time
            gameState.Time = gameState.Time.Increment(1);

            // Return the 'new' state
            return gameState;
        }
    }
}
using System.Collections.Generic;

namespace MattEland.Starship.Logic
{
    public class GameState
    {
        public GameState(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public int ClosedCount { get; set; } = 0;
        public GameTime Time { get; set; } = new GameTime(8, 4, 2422, 3, 20);

        public IEnumerable<WorkItem> WorkItems { get; } = new List<WorkItem>();
        public IEnumerable<CrewMember> Crew { get; } = new List<CrewMember>();
        public IEnumerable<ShipSystem> Systems { get; } = new List<ShipSystem>();
        public IEnumerable<GameMessage> Messages { get; } = new List<GameMessage>();
    }
}

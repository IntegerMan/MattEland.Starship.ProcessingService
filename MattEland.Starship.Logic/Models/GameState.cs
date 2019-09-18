using System.Collections.Generic;

namespace MattEland.Starship.Logic.Models
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

        private readonly List<WorkItem> _workItems = new List<WorkItem>();
        public IEnumerable<WorkItem> WorkItems => _workItems;
        internal int NextWorkItemId => _workItems.Count + 1;

        private readonly List<CrewMember> _crew = new List<CrewMember>();
        public IEnumerable<CrewMember> Crew => _crew;
        internal int NextCrewId => _crew.Count + 1;

        private readonly List<ShipSystem> _systems = new List<ShipSystem>();
        public IEnumerable<ShipSystem> Systems => _systems;
        internal int NextSystemId => _systems.Count + 1;

        private readonly List<GameMessage> _messages = new List<GameMessage>();
        public IEnumerable<GameMessage> Messages => _messages;


        public void Add(CrewMember crewMember) => _crew.Add(crewMember);

        public void Add(IEnumerable<CrewMember> crewMember) => _crew.AddRange(crewMember);

        public void Add(IEnumerable<WorkItem> workItems) => _workItems.AddRange(workItems);

        public void Add(IEnumerable<ShipSystem> shipSystems) => _systems.AddRange(shipSystems);
    }
}

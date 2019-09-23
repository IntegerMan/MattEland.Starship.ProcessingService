using System;
using System.Collections.Generic;
using System.Linq;
using MattEland.Starship.Logic.Models;
using MattEland.Starship.Logic.Models.Crew;
using OneOf;

namespace MattEland.Starship.Logic.Simulation
{
    public class CrewContext
    {
        public CrewMember CrewMember { get; }
        public GameState State { get; }
        public Random Random { get; }

        public CrewContext(CrewMember crewMember, GameState gameState, Random random)
        {
            CrewMember = crewMember;
            State = gameState;
            Random = random;
        }

        public IEnumerable<WorkItem> AllItems => State.WorkItems;
        public IEnumerable<WorkItem> UnassignedItems => AllItems.Where(wi => wi.AssignedCrewId == null);
        public IEnumerable<WorkItem> AssignedItems => AllItems.Where(wi => wi.AssignedCrewId == CrewMember.Id);

        public int GetRandomNumber(int min, int max) => Random.Next(min - 1, max + 1);
    }
}
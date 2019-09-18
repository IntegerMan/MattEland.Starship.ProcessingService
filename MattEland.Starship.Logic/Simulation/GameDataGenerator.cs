using System.Linq;
using Bogus;
using Bogus.Extensions;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation
{
    internal static class GameDataGenerator
    {
        internal static GameState GenerateCrewMembers(this GameState state, int count)
        {
            int nextId = state.NextCrewId;

            var faker = new Faker<CrewMember>()
                .RuleFor(c => c.Id, f => nextId++)
                .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                .RuleFor(c => c.LastName, f => f.Person.LastName)
                .RuleFor(c => c.Department, f => f.PickRandom<Department>())
                .RuleFor(c => c.Rank, f => f.PickRandom<Rank>())
                .RuleFor(c => c.DaysInRank, f => f.Random.Int(0, 500));

            state.Add(faker.Generate(count));

            return state;
        }

        internal static GameState GenerateSystems(this GameState state, int count)
        {
            int nextId = state.NextSystemId;

            var faker = new Faker<ShipSystem>()
                .CustomInstantiator(f => new ShipSystem(nextId++))
                .RuleFor(c => c.Name, f => f.Commerce.ProductName());

            state.Add(faker.Generate(count));

            return state;
        }

        internal static GameState GenerateWorkItems(this GameState state, int count)
        {
            int nextId = 1;
            if (state.WorkItems.Any())
            {
                nextId = state.WorkItems.Max(c => c.Id) + 1;
            }

            var faker = new Faker<WorkItem>()
                .CustomInstantiator(f => new WorkItem(nextId++))
                .RuleFor(c => c.Title, f => f.Hacker.Phrase())
                .RuleFor(c => c.Department, f => f.PickRandom<Department>())
                .RuleFor(c => c.Status, f => WorkItemStatus.New) // Simplest to start with everything in new
                .RuleFor(c => c.Priority, f => f.PickRandom<Priority>())
                .RuleFor(c => c.WorkItemType, f => WorkItemType.Incident)
                .RuleFor(c => c.CreatedByCrewId, f => f.PickRandom(state.Crew).Id)
                .RuleFor(c => c.SystemId, f => f.PickRandom(state.Systems).Id)
.RuleFor(c => c.AssignedCrewId, f => f.PickRandom(state.Crew.Select(c => c.Id))
                                                    .OrNull(f, 0.85f));


            state.Add(faker.Generate(count));

            return state;
        }
    }
}
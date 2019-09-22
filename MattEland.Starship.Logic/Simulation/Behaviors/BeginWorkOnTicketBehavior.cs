using System.Linq;
using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class BeginWorkOnTicketBehavior : CrewBehaviorNode
    {
        public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
        {
            var assignedTickets = context.State.WorkItems.Where(wi => wi.AssignedCrewId == context.CrewMember.Id &&
                                                                      wi.Status == WorkItemStatus.ReadyForWork).ToList();

            if (!assignedTickets.Any()) return PassedResult(context);

            var ticket = assignedTickets.First();
            ticket.Status = WorkItemStatus.InProgress;

            AddMessage(context, $"{context.CrewMember.FullName} begins work on {ticket.Title}");

            return MatchedResult(context);
        }
    }
}
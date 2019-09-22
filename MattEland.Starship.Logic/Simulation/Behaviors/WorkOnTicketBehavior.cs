using System.Linq;
using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class WorkOnTicketBehavior : CrewBehaviorNode
    {
        public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
        {
            var assignedTickets = context.State.WorkItems.Where(wi => wi.AssignedCrewId == context.CrewMember.Id &&
                                                                      wi.Status == WorkItemStatus.InProgress).ToList();

            if (!assignedTickets.Any()) return PassedResult(context);

            var ticket = assignedTickets.First();

            // TODO: Don't just make full progress - partial progress is something we should do, plus some degree of randomness.

            AddMessage(context, $"{context.CrewMember.FullName} finishes work on {ticket.Title}");

            ticket.Status = WorkItemStatus.ReadyForReview; // TODO: Would be nice to call ticket.AdvanceToNextStage

            return MatchedResult(context);
        }
    }
}
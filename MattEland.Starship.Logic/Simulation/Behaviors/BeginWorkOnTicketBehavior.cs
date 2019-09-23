using System.Linq;
using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class BeginWorkOnTicketBehavior : CrewBehaviorNode
    {
        public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
        {
            var ticket = context.AssignedItems.FirstOrDefault(wi => wi.Status == WorkItemStatus.ReadyForWork);

            if (ticket == null) return SkippedResult(context);

            ticket.Status = WorkItemStatus.InProgress;

            AddMessage(context, $"{context.CrewMember.FullName} begins work on {ticket.Title}");

            return MatchedResult(context);
        }
    }
}
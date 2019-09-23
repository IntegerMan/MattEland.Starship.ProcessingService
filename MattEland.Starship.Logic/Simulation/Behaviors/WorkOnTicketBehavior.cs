using System.Linq;
using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;
using OneOf;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class WorkOnTicketBehavior : CrewBehaviorNode
    {
public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
{
    var ticket = context.AssignedItems.FirstOrDefault(wi => wi.Status == WorkItemStatus.InProgress);

    if (ticket == null) return SkippedResult(context);

    return ProcessCrewWorkOnItem(context, ticket);
}

private BehaviorResult<CrewContext> ProcessCrewWorkOnItem(CrewContext context, WorkItem ticket)
{
    var result = GetWorkOnItemResult(context, ticket);

    result.Switch(
        completed =>
        {
            ticket.Status = WorkItemStatus.ReadyForReview;
            AddMessage(context, $"{context.CrewMember.FullName} finishes work on {ticket.Title}");
        },
        progress =>
        {
            ticket.ProgressMade++;
            AddMessage(context, $"{context.CrewMember.FullName} made steady progress on {ticket.Title}");
        },
        setback =>
        {
            if (setback.Severity > Priority.Normal)
            {
                ticket.ProgressMade -= 1;
                AddMessage(context, $"{context.CrewMember.FullName} encountered a setback on {ticket.Title}");
            }
            else
            {
                ticket.ProgressMade -= 1;
                AddMessage(context, $"{context.CrewMember.FullName} encountered a setback on {ticket.Title}");
            }
        }
    );

    return MatchedResult(context);
}

private OneOf<WorkCompletedResult, ProgressMadeResult, SetbackResult> GetWorkOnItemResult(
    CrewContext context, 
    WorkItem item)
{
    var roll = context.GetRandomNumber(1, 20);

    // Well, something is fundamentally wrong. Likely a mistaken assumption or bad requirement
    if (roll == 1)
    {
        return new SetbackResult(Priority.High);
    }

    // If we got a massive success, or we've previously made significant progress, it's done
    if (roll >= 20 - item.ProgressMade)
    {
        return new WorkCompletedResult(item);
    }

    // Okay, not a great roll, let's call it a setback
    if (roll < 3)
    {
        return new SetbackResult(Priority.Normal);
    }

    // Nothing much to see here - just a bit of progress
    return new ProgressMadeResult(item);
}
    }
}
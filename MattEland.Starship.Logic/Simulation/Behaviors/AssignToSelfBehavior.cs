using System.Linq;
using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class AssignToSelfBehavior : CrewBehaviorNode
    {
        public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
        {
            var item = context.UnassignedItems.FirstOrDefault(wi => wi.Status == WorkItemStatus.New ||
                                                              wi.Status == WorkItemStatus.ReadyForWork);

            if (item == null) return SkippedResult(context);

            item.AssignedCrewId = context.CrewMember.Id;

            if (item.Status == WorkItemStatus.New)
            {
                item.Status = WorkItemStatus.ReadyForWork;
                AddMessage(context, $"{context.CrewMember.FullName} marks {item.Title} as ready to work");
            }

            AddMessage(context, $"{context.CrewMember.FullName} assigns {item.Title} to themselves");

            return MatchedResult(context);

        }
    }
}
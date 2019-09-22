using System.Linq;
using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class AssignToSelfBehavior : CrewBehaviorNode
    {
        public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
        {
            var eligible = context.State.WorkItems.Where(wi => wi.AssignedCrewId == null &&
                                                               (wi.Status == WorkItemStatus.New ||
                                                                wi.Status == WorkItemStatus.ReadyForWork)).ToList();

            if (eligible.Any())
            {
                var item = eligible.First();
                item.AssignedCrewId = context.CrewMember.Id;
                item.Status = WorkItemStatus.ReadyForWork;

                return MatchedResult(context);
            }

            return PassedResult(context);
        }
    }
}
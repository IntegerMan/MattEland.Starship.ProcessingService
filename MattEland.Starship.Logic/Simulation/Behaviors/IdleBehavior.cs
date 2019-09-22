using MattEland.AI.BehaviorTrees;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class IdleBehavior : CrewBehaviorNode
    {
        public override BehaviorResult<CrewContext> Evaluate(CrewContext context)
        {
            AddMessage(context, $"{context.CrewMember.FullName} idles.");

            return MatchedResult(context);
        }
    }
}
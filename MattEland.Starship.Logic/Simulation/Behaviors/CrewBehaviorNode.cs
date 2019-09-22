using MattEland.AI.BehaviorTrees;
using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public abstract class CrewBehaviorNode : IBehaviorNode<CrewContext>
    {
        protected BehaviorResult<CrewContext> PassedResult(CrewContext context)
        {
            return new BehaviorResult<CrewContext>
            {
                Context = context,
                SelectedNode = null
            };
        }

        protected BehaviorResult<CrewContext> MatchedResult(CrewContext context)
        {
            return new BehaviorResult<CrewContext>
            {
                Context = context,
                SelectedNode = this
            };
        }

        public abstract BehaviorResult<CrewContext> Evaluate(CrewContext context);

        protected void AddMessage(CrewContext context, string message) 
            => context.State.Add(new GameMessage(message));
    }
}
using System.Collections.Generic;
using MattEland.AI.BehaviorTrees;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    public class CrewBehaviorTree : BehaviorTree<CrewContext>
    {
        public CrewBehaviorTree()
        {
            var behaviors = new List<IBehaviorNode<CrewContext>>
            {
                new WorkOnTicketBehavior(),
                new BeginWorkOnTicketBehavior(),
                new AssignToSelfBehavior(), 
                new IdleBehavior()
            };

            this.Child = new BehaviorSequence<CrewContext>(behaviors);
        }
    }
}
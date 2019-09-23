using MattEland.Starship.Logic.Models;

namespace MattEland.Starship.Logic.Simulation.Behaviors
{
    internal class SetbackResult
    {
        public SetbackResult(Priority severity)
        {
            Severity = severity;
        }

        public Priority Severity { get; }
    }
}
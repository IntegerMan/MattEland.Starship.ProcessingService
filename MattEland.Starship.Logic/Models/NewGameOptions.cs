namespace MattEland.Starship.Logic.Models
{
    public struct NewGameOptions
    {
        public NewGameOptions(int startingCrew, int startingSystems, int startingWorkItems)
        {
            StartingCrewMembers = startingCrew;
            StartingSystems = startingSystems;
            StartingWorkItems = startingWorkItems;
        }

        public int StartingCrewMembers { get; }
        public int StartingSystems { get; }
        public int StartingWorkItems { get; }
    }
}
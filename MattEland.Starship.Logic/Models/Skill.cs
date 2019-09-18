namespace MattEland.Starship.Logic.Models
{
    public struct Skill
    {
        public Skill(string internalName)
        {
            InternalName = internalName;
        }

        public bool Equals(Skill other)
        {
            return InternalName == other.InternalName;
        }

        public override bool Equals(object obj)
        {
            return obj is Skill other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (InternalName != null ? InternalName.GetHashCode() : 0);
        }

        public string InternalName { get; }
    }
}
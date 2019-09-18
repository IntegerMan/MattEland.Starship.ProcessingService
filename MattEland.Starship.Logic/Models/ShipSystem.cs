namespace MattEland.Starship.Logic.Models
{
    public class ShipSystem
    {
        public ShipSystem(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}
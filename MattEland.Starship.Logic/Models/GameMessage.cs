namespace MattEland.Starship.Logic.Models
{
    public struct GameMessage
    {
        public string Message { get; }

        public GameMessage(string message)
        {
            Message = message;
        }
    }
}
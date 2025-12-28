namespace Games.Infrastructure.Models
{
    // Ця таблиця наслідує GameEntity (Table-per-Type)
    public class OnlineGameEntity : GameEntity
    {
        public int MaxPlayers { get; set; }
    }
}
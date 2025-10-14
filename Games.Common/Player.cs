namespace Games.Common;

// незалежний клас
public class Player
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }

    // подія
    public delegate void GamePlayedHandler(string message);
    public event GamePlayedHandler? OnGamePlayed;

    // конструктор
    public Player(string nickname)
    {
        Id = Guid.NewGuid();
        Nickname = nickname;
    }

    public void Play(Game game)
    {
        OnGamePlayed?.Invoke($"{Nickname} почав грати у {game.Title}");
    }
}

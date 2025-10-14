namespace Games.Common;

// клас-нащадок
public class OnlineGame : Game
{
    public int MaxPlayers { get; set; }

    // конструктор
    public OnlineGame(string title, string genre, int year, int maxPlayers)
        : base(title, genre, year)
    {
        MaxPlayers = maxPlayers;
    }

    // метод
    public override void ShowInfo()
    {
        Console.WriteLine($"[ONLINE] {Title} ({Genre}) | {MaxPlayers} гравців");
    }
}

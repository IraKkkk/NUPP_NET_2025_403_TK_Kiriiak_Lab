namespace Games.Common;

// метод розширення
public static class PlayerExtensions
{
    public static void Greet(this Player player)
    {
        Console.WriteLine($"Гравець {player.Nickname} приєднався до гри!");
    }
}

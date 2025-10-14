namespace Games.Common;

// ще один клас-нащадок
public class OfflineGame : Game
{
    public bool HasStoryMode { get; set; }

    // конструктор
    public OfflineGame(string title, string genre, int year, bool hasStory)
        : base(title, genre, year)
    {
        HasStoryMode = hasStory;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[OFFLINE] {Title} ({Genre}) | Story Mode: {HasStoryMode}");
    }
}

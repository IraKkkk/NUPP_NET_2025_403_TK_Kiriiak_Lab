namespace Games.Common;

// базовий клас
public class Game
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    // конструктор
    public Game(string title, string genre, int year)
    {
        Id = Guid.NewGuid();
        Title = title;
        Genre = genre;
        Year = year;
    }

    // метод
    public virtual void ShowInfo()
    {
        Console.WriteLine($"{Title} - {Genre} ({Year})");
    }
}

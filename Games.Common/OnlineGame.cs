using System; // Обов'язково, щоб працював Random

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

    // --- ДОДАНИЙ КОД ДЛЯ ЛАБОРАТОРНОЇ №2 ---

    // 1. Статичний генератор (спільний для всіх ігор)
    private static Random Rnd = new Random();

    // 2. Статичний метод створення випадкової гри
    public static OnlineGame CreateNew()
    {
        // Масиви даних для випадкового вибору
        string[] titles = { "CS:GO 2", "Dota 2", "Minecraft", "Fortnite", "Apex Legends", "Valorant", "PUBG" };
        string[] genres = { "Shooter", "MOBA", "Survival", "Battle Royale", "Strategy" };

        // Вибираємо випадкові значення
        string title = titles[Rnd.Next(titles.Length)];
        string genre = genres[Rnd.Next(genres.Length)];
        int year = Rnd.Next(2010, 2026); // Рік від 2010 до 2025
        int maxPlayers = Rnd.Next(2, 101); // Гравців від 2 до 100

        // Повертаємо новий об'єкт, використовуючи твій конструктор
        return new OnlineGame(title, genre, year, maxPlayers);
    }
}
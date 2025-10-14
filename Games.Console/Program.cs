using Games.Common;

class Program
{
    static void Main()
    {
        var crud = new CrudService<Game>();

        var g1 = new OnlineGame("Valorant", "Shooter", 2020, 10);
        var g2 = new OfflineGame("The Witcher 3", "RPG", 2015, true);

        crud.Create(g1);
        crud.Create(g2);

        var player = new Player("Ira");
        player.OnGamePlayed += msg => Console.WriteLine(msg);

        // Використання події та методу розширення
        player.Greet();
        player.Play(g1);

        Console.WriteLine("\n🎮 Усі ігри:");
        foreach (var game in crud.ReadAll())
            game.ShowInfo();

        // демонстрація збереження
        crud.Save("games.json");
        Console.WriteLine("\n✅ Дані збережено у games.json");
    }
}

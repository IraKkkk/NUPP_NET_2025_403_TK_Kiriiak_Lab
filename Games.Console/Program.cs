using System;
using System.Linq; // Обов'язково для статистики (Min, Max)
using System.Threading.Tasks; // Для асинхронності
using Games.Common; // Підключаємо твої класи

class Program
{
    static async Task Main(string[] args)
    {
        // Щоб коректно відображалась кирилиця (якщо є)
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Lab 2: Games Multithreading ===");

        string filePath = "games_lab2.json";

        // 1. Створюємо сервіс (працюємо саме з OnlineGame)
        ICrudServiceAsync<OnlineGame> gameService = new FileCrudServiceAsync<OnlineGame>(filePath);

        Console.WriteLine("Генеруємо 1000 ігор паралельно...");

        // 2. PARALLEL: Паралельне створення об'єктів
        // Parallel.For розбиває задачу на потоки процесора
        Parallel.For(0, 1000, i =>
        {
            // Створюємо випадкову гру через твій метод
            var game = OnlineGame.CreateNew();
            
            // Додаємо в сервіс (синхронне очікування .Wait() для Parallel.For)
            gameService.CreateAsync(game).Wait(); 
        });

        Console.WriteLine("Генерацію завершено.");

        // 3. Збереження у файл (Асинхронно)
        Console.WriteLine("Зберігаємо у файл...");
        await gameService.SaveAsync();

        // 4. Отримання даних для аналізу
        // (Читаємо з файлу або пам'яті)
        var allGames = await gameService.ReadAllAsync();

        Console.WriteLine($"\nВсього ігор у базі: {allGames.Count()}");

        // 5. LINQ: Статистика
        if (allGames.Any())
        {
            // Шукаємо найстарішу та найновішу гру за роком
            int minYear = allGames.Min(g => g.Year);
            int maxYear = allGames.Max(g => g.Year);
            
            // Середній рік (Average повертає double)
            double avgYear = allGames.Average(g => g.Year);

            Console.WriteLine($"\n--- СТАТИСТИКА (LINQ) ---");
            Console.WriteLine($"Найстаріша гра: {minYear} рік");
            Console.WriteLine($"Найновіша гра:  {maxYear} рік");
            Console.WriteLine($"Середній рік випуску: {avgYear:F0}"); // F0 - без ком
        }

        // 6. ПАГІНАЦІЯ (Виводимо першу сторінку, 5 штук)
        Console.WriteLine("\n--- ПАГІНАЦІЯ (Перші 5 ігор) ---");
        var page1 = await gameService.ReadAllAsync(1, 5);
        
        foreach (var game in page1)
        {
            // Використовуємо твій метод ShowInfo
            game.ShowInfo();
        }

        Console.WriteLine("\nРоботу завершено. Натисніть Enter.");
        Console.ReadLine();
    }
}
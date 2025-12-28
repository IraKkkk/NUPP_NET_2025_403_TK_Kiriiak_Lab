using System;
using System.Threading.Tasks;
using Games.Common;            // Твої моделі (OnlineGame)
using Games.Infrastructure;    // Твій контекст і сервіси
using Games.Infrastructure.Models; // Твої таблиці
using Microsoft.EntityFrameworkCore; // Важливо для роботи з БД

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Lab 3: Database (SQLite) ===");

        // 1. Підключаємося до Бази Даних
        using var context = new GamesContext();
        
        // Гарантуємо, що база даних існує
        context.Database.EnsureCreated(); 

        // 2. Налаштовуємо сервіс роботи з БД
        var repository = new Repository<OnlineGameEntity>(context);
        
        // Використовуємо DbCrudService замість старого FileCrudServiceAsync
        ICrudServiceAsync<OnlineGame> dbService = new DbCrudService(repository);

        // 3. Генеруємо та додаємо дані
        Console.WriteLine("\nГенеруємо 5 нових ігор і зберігаємо в БД...");
        
        for (int i = 0; i < 5; i++)
        {
            var game = OnlineGame.CreateNew();
            await dbService.CreateAsync(game); // Тепер це пише в games.db
            Console.WriteLine($"Added: {game.Title}");
        }

        // 4. Читаємо з Бази Даних
        Console.WriteLine("\n--- Зчитуємо всі ігри з Бази Даних ---");
        var gamesFromDb = await dbService.ReadAllAsync();

        foreach (var g in gamesFromDb)
        {
            g.ShowInfo();
        }

        Console.WriteLine("\nГотово! Дані збережено у файл games.db");
    }
}
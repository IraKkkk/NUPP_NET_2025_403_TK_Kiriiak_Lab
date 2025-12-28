using System;

namespace Games.Infrastructure.Models
{
    public class GameEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        // Зв'язок з Розробником (зовнішній ключ)
        public Guid? DeveloperId { get; set; }
        public DeveloperEntity Developer { get; set; }

        // Зв'язок 1-до-1: Деталі гри
        public GameDetailsEntity Details { get; set; }
    }
}
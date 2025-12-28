using Microsoft.EntityFrameworkCore;
using Games.Infrastructure.Models;

namespace Games.Infrastructure
{
    public class GamesContext : DbContext
    {
        // Реєструємо наші таблиці
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<OnlineGameEntity> OnlineGames { get; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<GameDetailsEntity> GameDetails { get; set; }

        public GamesContext() { }
        public GamesContext(DbContextOptions<GamesContext> options) : base(options) { }

        // Налаштування підключення (SQLite)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Тут ми кажемо створити файл games.db
                optionsBuilder.UseSqlite("Data Source=games.db");
            }
        }

        // Налаштування зв'язків (Fluent API - вимога лаби)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. TPT (Table-per-Type): Окремі таблиці для різних типів ігор
            modelBuilder.Entity<GameEntity>().ToTable("Games");
            modelBuilder.Entity<OnlineGameEntity>().ToTable("OnlineGames");

            // 2. Зв'язок 1 Developer -> Багато Games
            modelBuilder.Entity<GameEntity>()
                .HasOne(g => g.Developer)
                .WithMany(d => d.Games)
                .HasForeignKey(g => g.DeveloperId);

            // 3. Зв'язок 1 Game <-> 1 Details
            modelBuilder.Entity<GameEntity>()
                .HasOne(g => g.Details)
                .WithOne(d => d.Game)
                .HasForeignKey<GameDetailsEntity>(d => d.GameId);
        }
    }
}
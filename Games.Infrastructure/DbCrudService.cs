using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Common; // Твої старі моделі
using Games.Infrastructure.Models; // Нові таблиці

namespace Games.Infrastructure
{
    public class DbCrudService : ICrudServiceAsync<OnlineGame>
    {
        private readonly IRepository<OnlineGameEntity> _repository;

        public DbCrudService(IRepository<OnlineGameEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(OnlineGame element)
        {
            // Перетворення: Твій клас -> Таблиця БД
            var entity = new OnlineGameEntity
            {
                Id = Guid.NewGuid(),
                Title = element.Title,
                Genre = element.Genre,
                Year = element.Year,
                MaxPlayers = element.MaxPlayers
            };
            
            await _repository.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<OnlineGame>> ReadAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            // Перетворення: Таблиця БД -> Твій клас
            return entities.Select(e => new OnlineGame(e.Title, e.Genre, e.Year, e.MaxPlayers)).ToList();
        }

        // Заглушки для інших методів (щоб програма не сварилася)
        public Task<OnlineGame> ReadAsync(Guid id) => throw new NotImplementedException();
        public Task<IEnumerable<OnlineGame>> ReadAllAsync(int p, int a) => throw new NotImplementedException();
        public Task<bool> UpdateAsync(OnlineGame e) => throw new NotImplementedException();
        public Task<bool> RemoveAsync(OnlineGame e) => throw new NotImplementedException();
        public Task<bool> SaveAsync() => Task.FromResult(true);
        public System.Collections.Generic.IEnumerator<OnlineGame> GetEnumerator() => throw new NotImplementedException();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
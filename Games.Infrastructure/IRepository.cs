using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
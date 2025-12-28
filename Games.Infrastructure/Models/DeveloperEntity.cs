using System;
using System.Collections.Generic;

namespace Games.Infrastructure.Models
{
    public class DeveloperEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        // Зв'язок: Один розробник має багато ігор
        public List<GameEntity> Games { get; set; } = new();
    }
}
using System;

namespace CommonCore.Repo.Entities
{
    public abstract class EntityBase : IEntity
    {
        public Guid ID { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedUTC { get; set; } = null;
    }
}

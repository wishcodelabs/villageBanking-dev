

namespace VBMS.Domain.SeedWork;

public class Entity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
}

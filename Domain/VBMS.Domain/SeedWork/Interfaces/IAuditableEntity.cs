namespace VBMS.Domain.Interfaces;

public interface IAuditableEntity<TKey> : IAuditableEntity, IEntity<TKey>
{
}
public interface IAuditableEntity : IEntity
{
    int CreatedBy { get; set; }

    DateTime CreatedOn { get; set; }

    int LastModifiedBy { get; set; }

    DateTime? LastModifiedOn { get; set; }
}

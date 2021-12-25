namespace VBMS.Domain.SeedWork.Interfaces;

public interface IAuditableEntity<TKey> : IAuditableEntity, IEntity<TKey>
{
}
public interface IAuditableEntity : IEntity
{
    string CreatedBy { get; set; }

    DateTime CreatedOn { get; set; }

    string LastModifiedBy { get; set; }

    DateTime? LastModifiedOn { get; set; }
}

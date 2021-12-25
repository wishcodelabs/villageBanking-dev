using VBMS.Domain.SeedWork.Interfaces;

namespace VBMS.Domain.SeedWork;

public class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
{

    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}

namespace VBMS.Domain.SeedWork;

public class AuditableEntity<TKey> : IAuditableEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}

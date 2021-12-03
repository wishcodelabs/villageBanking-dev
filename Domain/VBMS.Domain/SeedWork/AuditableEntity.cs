﻿namespace VBMS.Domain.SeedWork;

public class AuditableEntity<TKey> : IAuditableEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}

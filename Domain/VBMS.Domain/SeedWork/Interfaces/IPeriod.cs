namespace VBMS.Domain.SeedWork;

public interface IPeriod : IAuditableEntity
{
    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}
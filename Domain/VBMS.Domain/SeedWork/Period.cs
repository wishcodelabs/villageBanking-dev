namespace VBMS.Domain.SeedWork;

public abstract class Period : AuditableEntity<int>, IPeriod
{
    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public PeriodStatus Status { get; set; }
}

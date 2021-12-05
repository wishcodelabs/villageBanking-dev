namespace VBMS.Domain.SeedWork;

public class Period : AuditableEntity<int>, IPeriod
{
    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}

namespace VBMS.Domain.SeedWork;

public interface IPeriod : IAuditableEntity
{
    [DataType(DataType.Date)]
    DateTime BeginDate { get; set; }

    [DataType(DataType.Date)]
    DateTime EndDate { get; set; }

    PeriodStatus Status { get; set; }
}

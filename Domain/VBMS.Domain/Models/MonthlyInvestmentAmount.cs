namespace VBMS.Domain.Models;

public class MonthlyInvestmentAmount : AuditableEntity<int>
{
    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }


}

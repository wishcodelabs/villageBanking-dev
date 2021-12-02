namespace VBMS.Domain.Models;

public class LoanInterestRate : AuditableEntity<int>
{
    public int LoanTypeId { get; set; }

    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public double InterestRate { get; set; }
}

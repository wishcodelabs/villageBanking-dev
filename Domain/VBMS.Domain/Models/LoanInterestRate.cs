namespace VBMS.Domain.Models;

public class LoanInterestRate : AuditableEntity<int>
{
    public int LoanTypeId { get; set; }

    public double InterestRate { get; set; }
}

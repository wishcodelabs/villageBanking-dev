namespace VBMS.Domain.Models;

public class LoanInterestRate : AuditableEntity<int>
{
    public int LoanTypeId { get; set; }

    public InterestType InterestType { get; set; }

    [Required, Range(1, 10000000, ErrorMessage = "Can't be empty")]
    public int PeriodId { get; set; }

    public double InterestRate { get; set; }

    [ForeignKey(nameof(PeriodId))]
    public virtual InvestmentPeriod Period { get; set; }
    public virtual LoanType LoanType { get; set; }
}

namespace VBMS.Domain.Models;

public class LoanInterestRate : AuditableEntity<int>
{
    public int LoanTypeId { get; set; }

    public InterestType InterestType { get; set; }

    public int PeriodId { get; set; }

    public double InterestRate { get; set; }

    [ForeignKey(nameof(PeriodId))]
    public virtual InvestmentPeriod Period { get; set; }
    public virtual LoanType LoanType { get; set; }
}

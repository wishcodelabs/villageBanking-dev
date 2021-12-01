namespace VBMS.Domain.Models;

public class LoanType : AuditableEntity<int>
{
    public string LoanName { get; set; }

    public int LoanInterestRateId { get; set; }

    public decimal MaxLoanAmount { get; set; }

    [DataType(DataType.Duration)]
    public TimeSpan PaybackDuration { get; set; }

    public LoanInterestRate LoanInterestRate { get; set; }
}

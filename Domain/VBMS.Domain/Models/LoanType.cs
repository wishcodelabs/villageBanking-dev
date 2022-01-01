namespace VBMS.Domain.Models;

public class LoanType : AuditableEntity<int>
{
    [Required(ErrorMessage = "Loan name can't be empty")]
    public string LoanName { get; set; }

    public int GroupId { get; set; }

    public bool IsActive { get; set; }

    public decimal MaxLoanAmount { get; set; }

    public int PaybackDuration { get; set; }

    public virtual List<LoanInterestRate> InterestRates { get; set; }
    [ForeignKey(nameof(GroupId))]
    public virtual VillageBankGroup VillageBankGroup { get; set; }
}

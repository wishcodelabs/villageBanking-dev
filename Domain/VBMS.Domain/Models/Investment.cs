namespace VBMS.Domain.Models;

public class Investment : AuditableEntity<int>
{
    [Required, Range(1, int.MaxValue, ErrorMessage = "Can't be empty")]
    public int InvestorId { get; set; }

    public DateTime? DateInvested { get; set; }

    [Required, Range(1, int.MaxValue, ErrorMessage = "Can't be empty")]
    public int InvestmentPeriodId { get; set; }

    [Required, Range(1, int.MaxValue, ErrorMessage = "Can't be empty or zero")]
    public decimal AmountInvested { get; set; }

    public Status Status { get; set; }

    public InvestmentPeriod Period { get; set; }

    [ForeignKey(nameof(InvestorId))]
    public virtual VillageGroupMembership Investor { get; set; }
    public Investment()
    {
        DateInvested = DateTime.Now;
    }
    [NotMapped]
    public bool IsSelected { get; set; }
}

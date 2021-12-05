namespace VBMS.Domain.Models;

public class Investment : Entity<int>
{
    public int InverstorId { get; set; }

    public DateTime DateInvested { get; set; }

    public int InvestmentPeriodId { get; set; }

    public decimal AmountInvested { get; set; }

    public Status Status { get; set; }

    public InvestmentPeriod InvestmentPeriod { get; set; }

    [ForeignKey(nameof(InverstorId))]
    public virtual VillageGroupMembership Investor { get; set; }

}

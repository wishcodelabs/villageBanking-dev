namespace VBMS.Domain.Models;

public class Investment : Entity<int>
{
    public int InverstorId { get; set; }

    public DateTime DateInvested { get; set; }

    public int InvestmentPeriodId { get; set; }

    public InvestmentPeriod InvestmentPeriod { get; set; }

    [ForeignKey(nameof(InverstorId))]
    public virtual VillageGroupMember Investor { get; set; }

}

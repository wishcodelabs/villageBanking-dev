
namespace VBMS.Domain.Models;

public class VillageGroupMemberShare : AuditableEntity<int>
{
    public int MemberId { get; set; }

    public int InvestmentPeriodId { get; set; }

    public double NumberOfShares { get; set; }

    [ForeignKey(nameof(MemberId))]
    public virtual VillageGroupMembership Shareholder { get; set; }

    public virtual InvestmentPeriod InvestmentPeriod { get; set; }
}

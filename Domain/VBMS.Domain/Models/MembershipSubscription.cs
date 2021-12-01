
namespace VBMS.Domain.Models;

public class MembershipSubscription : Entity<int>
{
    public int MemberId { get; set; }

    public MembershipLevel MembershipLevel { get; set; }

    public decimal SubscriptionAmount { get; set; }

    public bool Paid { get; set; }

    [ForeignKey(nameof(MemberId))]
    public virtual VillageGroupMember Subscriber { get; set; }
}

namespace VBMS.Domain.Models;

public class VillageGroupMembership : AuditableEntity<int>
{
    public int VillageGroupId { get; set; }

    public Guid UserGuid { get; set; }

    public DateTime DateJoined { get; set; }
    public VillageGroupMemberStatus Status { get; set; } = VillageGroupMemberStatus.Inactive;

    public List<MembershipSubscription> Subscriptions { get; set; }

    [ForeignKey(nameof(VillageGroupId))]
    public virtual VillageBankGroup VillageBankGroup { get; set; }

    public virtual List<Investment> Investments { get; set; }
    [ValidateComplexType]
    public virtual PersonalDetails PersonalDetails { get; set; }
    public virtual List<VillageGroupMemberRole> Roles { get; set; }
}

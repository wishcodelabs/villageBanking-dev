
namespace VBMS.Domain.Models;

public class VillageGroupMemberRole : Entity<int>
{
    public int MemberId { get; set; }

    public VillageGroupRole Role { get; set; }

    [ForeignKey(nameof(MemberId))]
    public virtual VillageGroupMember VillageGroupMember { get; set; }
}

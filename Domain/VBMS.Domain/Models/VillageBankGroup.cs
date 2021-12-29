namespace VBMS.Domain.Models;

public class VillageBankGroup : AuditableEntity<int>
{
    public string GroupName { get; set; }

    public virtual List<GroupAdmin> Admins { get; set; }

    public bool IsActive { get; set; }
    public virtual List<VillageGroupMembership> GroupMembers { get; set; }

}

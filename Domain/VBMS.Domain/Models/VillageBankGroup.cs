namespace VBMS.Domain.Models;

public class VillageBankGroup : AuditableEntity<int>
{
    public string GroupName { get; set; }

    public Address PhysicalAddress { get; set; }

    public int AdminId { get; set; }

    public Admin Admin { get; set; }

    public virtual List<VillageGroupMember> GroupMembers { get; set; }
}

namespace VBMS.Domain.Models;

public class VillageBankGroup : AuditableEntity<int>
{
    public string GroupName { get; set; }

    public Address PhysicalAddress { get; set; }

    public string AdminGuid { get; set; }
    public virtual List<VillageGroupMembership> GroupMembers { get; set; }
}

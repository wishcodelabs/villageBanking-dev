namespace VBMS.Infrastructure.Services.Application;

public class MembershipService : ServiceBase<VillageGroupMembership, int>
{
    public MembershipService(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
    {

    }
    public async Task<int> CountMembers(int groupId)
    {
        var members = await Repository.Entities().Where(m => m.VillageGroupId == groupId).ToListAsync();
        return members.Count;
    }
}

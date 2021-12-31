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
    public async Task<List<VillageGroupMembership>> GetMembers(int groupId)
    {
        return await Repository.Entities()
                               .Where(m => m.VillageGroupId == groupId)
                               .ToListAsync();
    }
    public async Task<VillageGroupMembership> GetMembershipAsync(Guid guid)
    {
        return await Repository.Entities(false).Include(m => m.VillageBankGroup).FirstOrDefaultAsync(m => m.UserGuid == guid);
    }
}

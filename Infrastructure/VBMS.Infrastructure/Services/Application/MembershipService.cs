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
    public async Task<VillageBankGroup> GetGroupAsync(Guid guid)
    {
        var m = await Repository.Entities(true).FirstOrDefaultAsync(m => m.UserGuid == guid);
        return m.VillageBankGroup;
    }
}

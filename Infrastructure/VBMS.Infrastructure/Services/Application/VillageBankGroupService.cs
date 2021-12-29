
namespace VBMS.Infrastructure.Services.Application
{
    public class VillageBankGroupService : ServiceBase<VillageBankGroup, int>
    {
        public VillageBankGroupService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<VillageBankGroup> GetGroup(string adminGuid)
        {
            return await Repository.Entities.FirstOrDefaultAsync(g => g.AdminGuid == adminGuid);
        }
        public async Task<int> GetGroupId(string adminGuid)
        {
            var group = await GetGroup(adminGuid);
            return group.Id;
        }
    }
}

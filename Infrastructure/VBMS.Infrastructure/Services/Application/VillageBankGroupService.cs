
namespace VBMS.Infrastructure.Services.Application
{
    public class VillageBankGroupService : ServiceBase<VillageBankGroup, int>
    {
        public VillageBankGroupService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<bool> ActivateGroup(int groupId)
        {
            var group = await GetByIdAsync(groupId);
            if (group == null)
            {
                return false;
            }
            group.IsActive = true;
            return await UpdateAsync(group);
        }

    }
}

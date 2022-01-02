using Microsoft.Extensions.Caching.Memory;

namespace VBMS.Infrastructure.Services.Application
{
    public class GroupMemberRoleService : ServiceBase<VillageGroupMemberRole, int>
    {
        public GroupMemberRoleService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task<bool> IsChairperson(Guid userGuid)
        {
            var list = await GetMemberRolesAsync(userGuid);
            return list.ToList().Any(r => r.Role == VillageGroupRole.Chairperson);
        }
        public async Task<IEnumerable<VillageGroupMemberRole>> GetMemberRolesAsync(Guid userGuid)
        {
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) };
            return await Repository.Entities().Where(r => r.VillageGroupMember.UserGuid == userGuid).FromCacheAsync(options);
        }
    }
}

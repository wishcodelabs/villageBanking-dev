namespace VBMS.Infrastructure.Services.Application
{
    public class GroupAdminService : ServiceBase<GroupAdmin, int>
    {
        public GroupAdminService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<bool> IsAlreadyAdmin(Guid userGuid)
        {
            var admin = await Repository.Entities().FirstOrDefaultAsync(g => g.UserGuid == userGuid);
            return admin != null;
        }
        public async Task<GroupAdmin> GetByUserGuid(Guid userGuid)
        {
            return await Repository.Entities().FirstOrDefaultAsync(g => g.UserGuid == userGuid);
        }
    }
}

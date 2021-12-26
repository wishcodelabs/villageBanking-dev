namespace VBMS.Infrastructure.Services.Application
{
    public class GroupMemberRoleService : ServiceBase<VillageGroupMemberRole, int>
    {
        public GroupMemberRoleService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}

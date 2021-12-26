namespace VBMS.Infrastructure.Services.Application
{
    public class GroupMemberShareService : ServiceBase<VillageGroupMemberShare, int>
    {
        public GroupMemberShareService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}

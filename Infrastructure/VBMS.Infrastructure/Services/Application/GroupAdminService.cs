namespace VBMS.Infrastructure.Services.Application
{
    public class GroupAdminService : ServiceBase<GroupAdmin, int>
    {
        public GroupAdminService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}


namespace VBMS.Infrastructure.Services.Application
{
    public class VillageBankGroupService : ServiceBase<VillageBankGroup, int>
    {
        public VillageBankGroupService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }

    }
}

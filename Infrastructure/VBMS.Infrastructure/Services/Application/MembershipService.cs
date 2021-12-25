namespace VBMS.Infrastructure.Services.Application;

public class MembershipService : ServiceBase<VillageGroupMembership, int>
{
    public MembershipService(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
    {

    }
}

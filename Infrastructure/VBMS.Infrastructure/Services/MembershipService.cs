namespace VBMS.Infrastructure.Services;

public class MembershipService : ServiceBase<VillageGroupMembership, int>
{
    public MembershipService(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
    {

    }
}

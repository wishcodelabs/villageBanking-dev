namespace VBMS.Infrastructure.Managers;

public class MembershipManager : ManagerBase<VillageGroupMembership, int>
{
    public MembershipManager(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
    {

    }
}

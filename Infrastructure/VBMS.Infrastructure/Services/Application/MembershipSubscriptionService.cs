namespace VBMS.Infrastructure.Services.Application
{
    public class MembershipSubscriptionService : ServiceBase<MembershipSubscription, int>
    {
        public MembershipSubscriptionService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}

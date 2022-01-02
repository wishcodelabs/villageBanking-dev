namespace VBMS.Infrastructure.Services.Application
{
    public class GroupMemberShareService : IService
    {
        readonly InvestmentService investmentService;
        readonly MembershipService membershipService;
        public GroupMemberShareService(InvestmentService service, MembershipService _membershipService)
        {
            investmentService = service;
            membershipService = _membershipService;
        }

        public async Task<VillageGroupMemberShare> GetMemberShare(int periodId, int groupId, int memberId)
        {
            var totalAmount = 0.0M;
            var myInvestment = 0.0M;

            var totalInvestments = await investmentService.GetByPeriod(periodId, groupId);
            var mm = totalInvestments.Where(x => x.InvestorId == memberId).ToList();
            totalInvestments.ForEach(i => totalAmount += i.AmountInvested);
            mm.ForEach(i => myInvestment += i.AmountInvested);
            var share = new VillageGroupMemberShare
            {
                NumberOfShares = (double)(myInvestment / totalAmount),
                TotalInvestment = myInvestment
            };
            return share;
        }
    }
}

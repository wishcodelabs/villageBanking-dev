namespace VBMS.Infrastructure.Services.Application
{
    public class GroupMemberShareService : IService
    {
        readonly InvestmentService investmentService;


        public GroupMemberShareService(InvestmentService service)
        {
            investmentService = service;

        }

        public async Task<VillageGroupMemberShare> GetMemberShare(int periodId, int groupId, int memberId)
        {
            var totalAmount = 0.0M;
            var myInvestment = 0.0M;

            var totalInvestments = await investmentService.GetPeriodicallyByStatus(Status.Approved, groupId, periodId);
            var mm = totalInvestments.Where(x => x.InvestorId == memberId).ToList();
            totalInvestments.ForEach(i => totalAmount += i.AmountInvested);
            mm.ForEach(i => myInvestment += i.AmountInvested);
            var myshare = totalAmount <= 0 ? 0 : (double)(myInvestment / totalAmount);
            var share = new VillageGroupMemberShare
            {
                NumberOfShares = myshare,
                TotalInvestment = myInvestment
            };
            return share;
        }
    }
}

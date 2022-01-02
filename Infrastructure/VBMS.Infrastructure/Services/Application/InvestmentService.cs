namespace VBMS.Infrastructure.Services.Application
{
    public class InvestmentService : ServiceBase<Investment, int>
    {
        public InvestmentService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<List<Investment>> GetByGroup(int groupId)
        {
            return await Repository.Entities().OrderByDescending(i => i.DateInvested).Where(i => i.Investor.VillageGroupId == groupId).ToListAsync();
        }
        public async Task<List<Investment>> GetByPeriod(int period, int groupId)
        {
            if (period == 0)
            {
                return await GetByGroup(groupId);
            }
            return await Repository.Entities().OrderByDescending(i => i.DateInvested).Where(i => i.Investor.VillageGroupId == groupId && i.InvestmentPeriodId == period).ToListAsync();
        }
    }
}

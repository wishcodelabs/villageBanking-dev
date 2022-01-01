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
    }
}

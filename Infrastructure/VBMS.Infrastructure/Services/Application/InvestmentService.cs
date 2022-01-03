using Microsoft.Extensions.Caching.Memory;

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
        public async Task<List<Investment>> SearchAsync(string searchString, int groupId)
        {
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(10) };
            var items = await Repository.Entities().Where(i => i.Investor.VillageGroupId == groupId).FromCacheAsync(options);
            var list = items.Where(i =>
                                                    i.Investor.PersonalDetails.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                                    i.Investor.PersonalDetails.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                                    i.Investor.PersonalDetails.NrcNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                                    ((DateTime)i.DateInvested).ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                                    i.CreatedBy.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                                    ).ToList();
            return list;
        }
        public async Task<List<Investment>> GetPeriodicallyByStatus(Status status, int groupId, int periodId)
        {
            var list = await GetByPeriod(periodId, groupId);
            return list.Where(l => l.Status == status).ToList();
        }
        public async Task<bool> ToggleStatus(Investment record)
        {
            if (record.Status == Status.Pending)
            {
                record.Status = Status.Approved;
            }
            else
            {

            }
            return await UpdateAsync(record);
        }
    }
}

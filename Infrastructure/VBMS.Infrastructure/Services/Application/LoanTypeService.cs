using Microsoft.Extensions.Caching.Memory;

namespace VBMS.Infrastructure.Services.Application
{
    public class LoanTypeService : ServiceBase<LoanType, int>
    {
        public LoanTypeService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<List<LoanType>> GetLoanTypes(int groupId)
        {

            return await Repository.Entities().Where(l => groupId.Equals(l.GroupId)).ToListAsync();
        }
        public async Task<bool> ToggleActive(LoanType record)
        {
            record.IsActive = !record.IsActive;

            return await UpdateAsync(record);
        }

        public async Task<List<LoanType>> GetActive(int villageGroupId)
        {
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(1) };
            var list = await Repository.Entities().FromCacheAsync(options);

            return list.Where(l => l.IsActive && l.GroupId == villageGroupId).ToList();
        }

        public async Task<decimal> GetMaximumLoanAmount(int loanTypeId)
        {
            var loanType = await Repository.Entities(false).FirstOrDefaultAsync(t => t.Id == loanTypeId);
            return loanType.MaxLoanAmount;
        }
    }
}

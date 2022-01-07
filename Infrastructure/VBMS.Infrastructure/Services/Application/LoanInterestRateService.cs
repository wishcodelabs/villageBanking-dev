using Microsoft.Extensions.Caching.Memory;

namespace VBMS.Infrastructure.Services.Application
{
    public class LoanInterestRateService : ServiceBase<LoanInterestRate, int>
    {
        public LoanInterestRateService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public IEnumerable<LoanInterestRate> GetByLoanType(int loanTypeId)
        {
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(1) };
            if (loanTypeId == 0)
            {
                return new List<LoanInterestRate>();
            }

            return Repository.Entities().FromCache(options).Where(i => i.LoanTypeId == loanTypeId).ToList();
        }
    }
}

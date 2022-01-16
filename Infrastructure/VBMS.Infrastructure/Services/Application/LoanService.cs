using Microsoft.Extensions.Caching.Memory;

namespace VBMS.Infrastructure.Services.Application
{
    public class LoanService : ServiceBase<Loan, int>
    {
        public LoanService(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<List<Loan>> GetAllByMemberId(int memberId, int periodId)
        {
            var all = await Repository
                         .Entities()
                         .Include(l => l.ApplicationRequest)
                                                .ThenInclude(a => a.Applicant)
                                                .ThenInclude(m => m.PersonalDetails)
                         .Include(l => l.ApplicationRequest)
                                                .ThenInclude(a => a.LoanType)
                         .Where(l => l.ApplicationRequest.ApplicantId == memberId)
                         .ToListAsync();
            if (all == null)
            {
                return new List<Loan>();
            }
            if (periodId == 0)
            {
                return all;
            }
            else
            {
                return all.Where(l => l.PeriodId == periodId).ToList();
            }
        }
        public async Task<List<Loan>> GetByStatusAsync(LoanStatus loanStatus)
        {
            return await Repository
                         .Entities()
                         .Where(l => l.Status == loanStatus)
                         .ToListAsync();

        }
        public async Task<List<Loan>> GetByGroup(int groupId, int periodId)
        {
            var all = await Repository.Entities(true)
                                                .Include(l => l.ApplicationRequest)
                                                .ThenInclude(a => a.Applicant)
                                                .ThenInclude(m => m.PersonalDetails)
                                                .Include(l => l.ApplicationRequest)
                                                .ThenInclude(a => a.LoanType)
                                                .Where(l => l.ApplicationRequest.Applicant.VillageGroupId == groupId).ToListAsync();
            if (all == null)
            {
                return new List<Loan>();
            }
            if (periodId == 0)
            {
                return all;
            }
            else
            {
                return all.Where(l => l.PeriodId == periodId).ToList();
            }
        }
        public async Task<bool> HasDefaulted(int applicant)
        {
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(24) };
            var list = await Repository.Entities().FromCacheAsync(options);
            var loans = list.Where(l => l.ApplicationRequest.ApplicantId == applicant);

            var hasLoan = loans.Any();
            var hasDefaulted = loans.Any(l => l.Status == LoanStatus.Defaulted) || loans.Any(l => l.Status == LoanStatus.Due && !l.Payments.Any());

            return hasLoan && hasDefaulted;

        }

    }
}

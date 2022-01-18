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

        public async Task<List<Loan>> GetPaidOff()
        {
            var paid = new List<Loan>();
            var all = await Repository.Entities().Where(l => l.Status != LoanStatus.Paid).ToListAsync();
            foreach (var loan in all)
            {
                var totalPayments = 0M;
                loan.Payments.ForEach(p => totalPayments += p.Amount);
                if (totalPayments >= loan.GetAmountOwing())
                {
                    paid.Add(loan);
                }
            }
            return paid;
        }

        public async Task<decimal> GetTotalDebtorsByGroup(int groupId, int periodId)
        {
            var loans = await GetByGroup(groupId, periodId);
            var totalDebtors = 0M;
            loans.ForEach((loan) => { totalDebtors += loan.GetAmountOwing(); });
            return totalDebtors;
        }

        public async Task<List<Loan>> GetDefaulted()
        {
            return await Repository.Entities().Where(l => l.Status == LoanStatus.Due && l.DateDue.Date <= DateTime.Now.AddDays(-3)).ToListAsync();

        }

        public async Task<decimal> GetTotalDebtByMembershipId(int memberId, int currentPeriod)
        {
            var loans = await GetAllByMemberId(memberId, currentPeriod);
            var totalDebt = 0M;
            loans.ForEach((loan) => { totalDebt += loan.GetAmountOwing(); });
            return totalDebt;
        }

        public async Task<List<Loan>> GetDue()
        {
            return await Repository.Entities().Where(l => l.DateDue.Date <= DateTime.Today && l.Status == LoanStatus.Active).ToListAsync();
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

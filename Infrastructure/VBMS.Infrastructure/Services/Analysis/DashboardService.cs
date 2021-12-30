namespace VBMS.Infrastructure.Services.Analysis
{
    public class DashboardService : IDashboardService
    {
        readonly SystemDbContext context;
        public DashboardService(SystemDbContext dbContext)
        {
            context = dbContext;
        }

        public Task<int> GetBadEggs(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public async Task<double> GetMonthlyInvestments(int groupId, int investmentPeriodId, int month)
        {
            var investments = await context.Set<Investment>()
                                                .Include(s => s.Investor)
                                                .Where(i => i.InvestmentPeriodId == investmentPeriodId && i.Investor.VillageGroupId == groupId && i.DateInvested.Month == month)
                                                .ToListAsync();
            var total = 0.0;
            investments.ForEach(x => { total += ((double)x.AmountInvested); });
            return total;
        }

        public Task<List<int>> GetMonthlyLoanApplications(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<List<double>> GetMonthlyRevenue(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNewLoanApplications(int groupId, int investmentPeriodId)
        {
            var loans = await context.Set<Loan>()
                                        .Include(l => l.Applicant)
                                        .ThenInclude(a => a.GroupMembership)
                                        .Where(l => l.DateSubmitted.Day == DateTime.Today.Day && l.Applicant.GroupMembership.VillageGroupId == groupId && l.Status == Status.Pending)
                                        .ToListAsync();
            return loans.Count;
        }

        public Task<List<int>> GetOverallPerf(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalInvestments(int groupId, int investmentPeriodId)
        {
            var total = 0.0M;
            var investments = await context.Set<Investment>()
                                                    .Include(s => s.Investor)
                                                    .Where(i => i.InvestmentPeriodId == investmentPeriodId && i.Investor.VillageGroupId == groupId)
                                                    .ToListAsync();
            investments.ForEach(x => { total += x.AmountInvested; });
            return total;

        }

        public async Task<double> GetTotalShares(int groupId, int investmentPeriodId)
        {
            var shares = await context.Set<VillageGroupMemberShare>()
                                        .Include(s => s.Shareholder)
                                        .Where(s => s.InvestmentPeriodId == investmentPeriodId && s.Shareholder.VillageGroupId == groupId)
                                        .ToListAsync();
            var total = 0.0;
            shares.ForEach(s => { total += s.NumberOfShares; });
            return total;
        }
    }
}

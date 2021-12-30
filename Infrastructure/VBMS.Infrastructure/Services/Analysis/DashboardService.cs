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

        public Task<List<double>> GetMonthlyInvestments(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetMonthlyLoanApplications(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<List<double>> GetMonthlyRevenue(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNewLoanApplications(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetOverallPerf(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetTotalInvestments(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalShares(int groupId, int investmentPeriodId)
        {
            throw new NotImplementedException();
        }
    }
}

namespace VBMS.Infrastructure.Services.Analysis
{
    public class DashboardService : IDashboardService
    {
        readonly SystemDbContext context;
        public DashboardService(SystemDbContext dbContext)
        {
            context = dbContext;
        }

        public Task<int> GetBadEggs(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<List<double>> GetMonthlyInvestments(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetMonthlyLoanApplications(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<List<double>> GetMonthlyRevenue(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNewLoanApplications(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetOverallPerf(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetTotalInvestments(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalShares(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}

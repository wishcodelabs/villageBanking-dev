namespace VBMS.Infrastructure.Interfaces
{
    public interface IDashboardService : IService
    {
        //Chat Data
        //Analysis Data etc
        Task<int> GetNewLoanApplications(int groupId, int investmentPeriodId);
        Task<double> GetTotalShares(int groupId, int investmentPeriodId);
        Task<decimal> GetTotalInvestments(int groupId, int investmentPeriodId);
        Task<int> GetBadEggs(int groupId, int investmentPeriodId);

        Task<double> GetMonthlyInvestments(int groupId, int investmentPeriodId, int month);

        Task<List<int>> GetMonthlyLoanApplications(int groupId, int investmentPeriodId);

        Task<List<double>> GetMonthlyRevenue(int groupId, int investmentPeriodId);
        Task<List<int>> GetOverallPerf(int groupId, int investmentPeriodId);

    }
}

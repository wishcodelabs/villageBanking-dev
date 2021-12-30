namespace VBMS.Infrastructure.Interfaces
{
    public interface IDashboardService : IService
    {
        //Chat Data
        //Analysis Data etc
        Task<int> GetNewLoanApplications(int groupId);
        Task<int> GetTotalShares(int groupId);
        Task<double> GetTotalInvestments(int groupId);
        Task<int> GetBadEggs(int groupId);

        Task<List<double>> GetMonthlyInvestments(int groupId);

        Task<List<int>> GetMonthlyLoanApplications(int groupId);

        Task<List<double>> GetMonthlyRevenue(int groupId);
        Task<List<int>> GetOverallPerf(int groupId);

    }
}

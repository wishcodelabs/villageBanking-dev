namespace VBMS.Infrastructure.Services.Analysis
{
    public class DashboardService : IDashboardService
    {
        readonly SystemDbContext context;
        public DashboardService(SystemDbContext dbContext)
        {
            context = dbContext;
        }
    }
}

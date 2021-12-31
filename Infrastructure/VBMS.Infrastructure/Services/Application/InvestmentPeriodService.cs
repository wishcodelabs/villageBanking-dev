namespace VBMS.Infrastructure.Services.Application;

public class InvestmentPeriodService : ServiceBase<InvestmentPeriod, int>
{
    public InvestmentPeriodService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
    {
    }
    public async Task<List<InvestmentPeriod>> GetByStatusAsync(PeriodStatus status, int groupId)
    {
        return await Repository
                     .Entities(false)
                     .Where(x => x.GroupId == groupId && x.Status == status)
                     .ToListAsync();
    }
    public async Task<bool> ClosePeriodAsync(InvestmentPeriod period)
    {
        period.Status = PeriodStatus.Closed;
        return await UpdateAsync(period);
    }
    public async Task<bool> OpenPeriodAsync(InvestmentPeriod period)
    {
        period.Status = PeriodStatus.Open;
        return await UpdateAsync(period);
    }
    public async Task<List<InvestmentPeriod>> GetInvestmentPeriodsAsync(int groupId)
    {
        return await Repository.Entities().Where(p => p.GroupId == groupId).ToListAsync();
    }
}

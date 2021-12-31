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
    public async Task<bool> ToggleStatusAsync(InvestmentPeriod period)
    {
        if (period.Status == PeriodStatus.Closed)
        {
            period.Status = PeriodStatus.Open;

        }
        else
        {
            period.Status = PeriodStatus.Closed;

        }

        return await UpdateAsync(period);

    }

    public async Task<List<InvestmentPeriod>> GetInvestmentPeriodsAsync(int groupId)
    {
        return await Repository.Entities().Where(p => p.GroupId == groupId).ToListAsync();
    }
}

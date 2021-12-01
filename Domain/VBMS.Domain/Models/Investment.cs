namespace VBMS.Domain.Models;

public class Investment : Entity<int>
{
    public int MemberId { get; set; }

    public DateTime DateInvested { get; set; }

    public int InvestmentPeriodId { get; set; }

    public InvestmentPeriod InvestmentPeriod { get; set; }

}

namespace VBMS.Domain.Models;

public class InvestmentPeriod : Period
{
    [DataType(DataType.Currency)]
    public decimal MinAmount { get; set; }

    public int GroupId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public virtual VillageBankGroup VillageBankGroup { get; set; }
}

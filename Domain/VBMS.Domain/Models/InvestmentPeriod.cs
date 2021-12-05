namespace VBMS.Domain.Models;

public class InvestmentPeriod : Period
{
    [DataType(DataType.Currency)]
    public decimal MinAmount { get; set; }
}

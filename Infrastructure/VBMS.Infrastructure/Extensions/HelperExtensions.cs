namespace VBMS.Infrastructure.Extensions;

public static class HelperExtensions
{

    public static decimal GetAmountOwing(this Loan loan)

        => loan.GetTotalInterest() + loan.ApprovedAmount;
    public static decimal GetTotalInterest(this Loan loan)
    {
        var totalInterest = 0.0;
        switch (loan.InterestRate.InterestType)
        {
            case InterestType.Simple:
                totalInterest = (double)loan.ApprovedAmount
                                * loan.InterestRate.InterestRate
                                * Convert.ToDouble(loan.InterestRate.PaybackDuration) / 100;
                break;
            case InterestType.Compound:
                {
                    var n = loan.InterestRate.PaybackDuration;
                    var p = (double)loan.ApprovedAmount;
                    var r = loan.InterestRate.InterestRate / 100;

                    totalInterest = p * (Math.Pow(1 + r, n) - 1);
                    break;
                }
        }

        return (decimal)totalInterest;

    }
}

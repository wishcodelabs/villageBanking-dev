namespace VBMS.Infrastructure.Extensions;

public static class HelperExtensions
{

    public static decimal GetAmountOwing(this Loan loan)

        => loan.GetTotalInterest() + loan.ApprovedAmount;
    public static decimal GetTotalInterest(this Loan loan)
    {
        var totalInterest = 0.0;
        var n = loan.InterestRate.PaybackDuration;
        var p = (double)loan.ApprovedAmount;
        var r = loan.InterestRate.InterestRate / 100;
        switch (loan.InterestRate.InterestType)
        {
            case InterestType.Simple:

                totalInterest = p * r * n;
                break;
            case InterestType.Compound:

                totalInterest = p * (Math.Pow(1 + r, n) - 1);
                break;

        }

        return (decimal)totalInterest;

    }
}

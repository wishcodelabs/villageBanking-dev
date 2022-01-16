namespace VBMS.Infrastructure.Extensions
{
    public static class HelperExtensions
    {

        public static decimal GetAmountOwing(this Loan loan)
        {
            return loan.GetTotalInterest() + loan.ApprovedAmount;
        }
        public static decimal GetTotalInterest(this Loan loan)
        {
            var totalInterest = 0.0;
            if (loan.InterestRate.InterestType == InterestType.Simple)
            {
                totalInterest = ((double)loan.ApprovedAmount * loan.InterestRate.InterestRate * Convert.ToDouble(loan.InterestRate.PaybackDuration * 7)) / (100 * 365);
            }
            else if (loan.InterestRate.InterestType == InterestType.Compound)
            {
                var p = (double)loan.ApprovedAmount;
                var r = loan.InterestRate.InterestRate / 100;
                var n = loan.InterestRate.PaybackDuration;
                totalInterest = p * ((1 + r) * n - 1);
            }

            return (decimal)totalInterest;

        }
    }
}

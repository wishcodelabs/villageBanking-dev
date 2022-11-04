using System.Security.Claims;

namespace VBMS.Infrastructure.Extensions;
public static class ClaimsPrincipalExtensions
{

    public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
       => claimsPrincipal.FindFirstValue(ClaimTypes.Email);
    public static string GetPhoneNumber(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue(ClaimTypes.MobilePhone);
    public static Guid GetGuid(this ClaimsPrincipal claimsPrincipal)
        => Guid.Parse(claimsPrincipal.FindFirstValue("Guid"));
    public static string GetFullName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue("FullName");
    public static string GetFirstName(this ClaimsPrincipal claimsPrincipal)
       => claimsPrincipal.FindFirstValue("FirstName");
    public static string GetLastName(this ClaimsPrincipal claimsPrincipal)
      => claimsPrincipal.FindFirstValue("LastName");
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        => Convert.ToInt32(claimsPrincipal.FindFirstValue("UserId"));
    public static string GetUserRole(this ClaimsPrincipal claimsPrincipal)
       => claimsPrincipal.FindFirstValue(ClaimTypes.Role);    


}
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

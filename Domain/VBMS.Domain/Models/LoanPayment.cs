namespace VBMS.Domain.Models;

public class LoanPayment : Entity<int>
{
    public string LoanNumber { get; set; }

    public int ApplicantId { get; set; }

    public int LoanId { get; set; }
}

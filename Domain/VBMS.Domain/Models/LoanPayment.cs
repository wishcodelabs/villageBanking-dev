namespace VBMS.Domain.Models;

public class LoanPayment : Entity<int>
{
    public string LoanNumber { get; set; }

    public int ApplicantId { get; set; }

    public int LoanId { get; set; }

    public DateTime Date { get; set; }

    public int Quarter { get; set; }

    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
}

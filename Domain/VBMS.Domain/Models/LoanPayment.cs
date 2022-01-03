namespace VBMS.Domain.Models;

public class LoanPayment : Entity<int>
{

    public int ApplicantId { get; set; }

    public int LoanId { get; set; }

    public DateTime Date { get; set; }

    public int Quarter { get; set; }

    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }

    public Status Status { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public virtual Loan Loan { get; set; }
}

namespace VBMS.Domain.Models
{
    public class LoanApplication : AuditableEntity<int>
    {
        public int ApplicantId { get; set; }

        public decimal RequestedAmount { get; set; }

        public DateTime DateSubmitted { get; set; }

        public LoanApplicationStatus Status { get; set; }

        public int LoanTypeId { get; set; }

        public string Details { get; set; }
        public virtual LoanType LoanType { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}

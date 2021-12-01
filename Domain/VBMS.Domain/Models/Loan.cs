namespace VBMS.Domain.Models
{
    public class Loan : AuditableEntity<int>
    {
        public string LoadNumber { get; set; }

        public int ApplicantId { get; set; }

        public decimal RequestedAmount { get; set; }

        public decimal ApprovedAmount { get; set; }

        public DateTime DateSubmitted { get; set; }

        public LoanStatus Status { get; set; }

        public int LoanTypeId { get; set; }

        public string Details { get; set; }
        public virtual LoanType LoanType { get; set; }
        public virtual Applicant Applicant { get; set; }

    }
}

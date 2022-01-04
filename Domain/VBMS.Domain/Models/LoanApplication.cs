namespace VBMS.Domain.Models
{
    public class LoanApplication : AuditableEntity<int>
    {
        public int ApplicantId { get; set; }

        public int PeriodId { get; set; }
        public decimal RequestedAmount { get; set; }

        public DateTime DateSubmitted { get; set; }

        public LoanApplicationStatus Status { get; set; }

        public int LoanTypeId { get; set; }

        [ForeignKey(nameof(PeriodId))]
        public InvestmentPeriod Period { get; set; }

        public string Details { get; set; }
        public virtual LoanType LoanType { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual List<UploadFile> Files { get; set; }
    }
}

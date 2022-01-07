namespace VBMS.Domain.Models
{
    public class LoanApplication : AuditableEntity<int>
    {
        public int ApplicantId { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Can't be none")]
        public int PeriodId { get; set; }
        [Required, Range(1.0, (double)decimal.MaxValue, ErrorMessage = "Can't not request zero amount")]
        public decimal RequestedAmount { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Can't be none")]
        public int InterestRateId { get; set; }

        public DateTime DateSubmitted { get; set; }

        public LoanApplicationStatus Status { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Can't be none")]
        public int LoanTypeId { get; set; }

        [ForeignKey(nameof(PeriodId))]
        public InvestmentPeriod Period { get; set; }

        public string Details { get; set; }
        public virtual LoanType LoanType { get; set; }
        [ForeignKey(nameof(ApplicantId))]
        public virtual VillageGroupMembership Applicant { get; set; }
        public virtual List<UploadFile> Files { get; set; }
        [ForeignKey(nameof(InterestRateId))]
        public virtual LoanInterestRate InterestRate { get; set; }
    }
}

namespace VBMS.Domain.Models
{
    public class Loan : AuditableEntity<int>
    {
        public int RequestId { get; set; }

        public decimal ApprovedAmount { get; set; }
        public int PeriodId { get; set; }

        public DateTime DateDue { get; set; }

        public DateTime DateApproved { get; set; }

        public LoanStatus Status { get; set; }

        public int ApproverId { get; set; }

        public int RatingId { get; set; }

        public string Details { get; set; }

        [ForeignKey(nameof(RequestId))]
        public virtual LoanApplication ApplicationRequest { get; set; }
        [ForeignKey(nameof(RequestId))]
        public virtual VillageGroupMembership Approver { get; set; }
        [ForeignKey(nameof(PeriodId))]
        public virtual InvestmentPeriod Period { get; set; }
        [ForeignKey(nameof(RatingId))]
        public virtual LoanInterestRate InterestRate { get; set; }
        public virtual List<LoanPayment> Payments { get; set; }

    }
}

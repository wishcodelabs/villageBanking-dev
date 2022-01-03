namespace VBMS.Domain.Models
{
    public class Loan : AuditableEntity<int>
    {
        public int ApplicationId { get; set; }

        public decimal ApprovedAmount { get; set; }

        public DateTime DateDue { get; set; }
        public DateTime DateApproved { get; set; }

        public LoanStatus Status { get; set; }

        public int ApproverId { get; set; }

        public int LoanTypeId { get; set; }

        public string Details { get; set; }
        public virtual LoanType LoanType { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public virtual LoanApplication ApplicationRequest { get; set; }
        [ForeignKey(nameof(ApplicationId))]
        public virtual VillageGroupMembership Approver { get; set; }
        public virtual List<LoanPayment> Payments { get; set; }

    }
}

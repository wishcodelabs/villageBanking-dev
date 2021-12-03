namespace VBMS.Domain.Models
{
    public class Applicant : Entity<int>
    {
        public int MembershipId { get; set; }

        [ForeignKey(nameof(MembershipId))]
        public VillageGroupMembership GroupMembership { get; set; }

    }
}
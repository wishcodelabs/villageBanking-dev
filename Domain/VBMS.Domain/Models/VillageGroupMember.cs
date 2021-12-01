namespace VBMS.Domain.Models
{
    public class VillageGroupMember : Entity<int>
    {
        public int VillageGroupId { get; set; }

        public int PersonalDetailsId { get; set; }

        public DateTime DateJoined { get; set; }
        public VillageGroupMemberStatus Status { get; set; }

        public List<MembershipSubscription> Subscriptions { get; set; }

        public virtual VillageBankGroup VillageBankGroup { get; set; }

        public virtual List<Investment> Investments { get; set; }
    }
}
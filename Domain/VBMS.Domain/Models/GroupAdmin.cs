namespace VBMS.Domain.Models
{
    public class GroupAdmin : Entity<int>
    {
        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual VillageBankGroup Group { get; set; }
        public GroupAdmin()
        {
            Guid = Guid.NewGuid();
        }
    }
}

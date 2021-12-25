namespace VBMS.Infrastructure.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
        public virtual ICollection<RoleClaim> Claims { get; set; }
        public Role(string name, string description) : base(name)
        {
            Description = description;
            Claims = new HashSet<RoleClaim>();
        }
    }

}

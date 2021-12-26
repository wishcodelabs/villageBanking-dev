namespace VBMS.Infrastructure.Models.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>, IEntity<int>
    {
        public string? Description { get; set; }
        public string? Group { get; set; }
        public virtual Role Role { get; set; }
        public RoleClaim() : base()
        {

        }
        public RoleClaim(string roleClaimDescription, string roleClaimGroup) : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
    }
}

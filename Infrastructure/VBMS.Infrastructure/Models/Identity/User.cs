namespace VBMS.Infrastructure.Models.Identity;

public class User : IdentityUser<int>, IAuditableEntity<int>
{
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public Guid UserGuid { get; set; }
    public bool IsActive { get; set; }
    public User()
    {
        UserGuid = Guid.NewGuid();
    }
}

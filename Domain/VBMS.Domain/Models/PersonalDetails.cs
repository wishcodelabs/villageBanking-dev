namespace VBMS.Domain.Models;

public class PersonalDetails
{
    const string nrc = @"^\d{6}\/d{2}\/d{1}$";

    public int MembershipId { get; set; }
    [Required(ErrorMessage = "First name can't be empty")]
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }
    [Required(ErrorMessage = "Last name can't be empty")]
    public string LastName { get; set; }
    [Required]
    [StringLength(11)]
    [RegularExpression(nrc, ErrorMessage = "Required format is 00000/00/0")]
    public string NrcNumber { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    [ValidateComplexType]
    public Address PhysicalAddress { get; set; }
    [Required]
    public string Occupation { get; set; }

    public Gender Gender { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    [ForeignKey(nameof(MembershipId))]
    public virtual VillageGroupMembership Owner { get; set; }


}

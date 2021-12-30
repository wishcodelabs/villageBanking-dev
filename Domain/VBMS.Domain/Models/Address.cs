namespace VBMS.Domain.Models;

public class Address
{
    [Required(ErrorMessage = "Address can't be empty")]
    public string HouseNumber { get; set; }
    [Required(ErrorMessage = "City can't be empty")]
    public int CityId { get; set; }
    public virtual City City { get; set; }

}

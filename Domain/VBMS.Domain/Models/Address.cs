namespace VBMS.Domain.Models;

public class Address : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return HouseNumber;
        yield return City;
        yield return Province;

    }
    [Required(ErrorMessage = "Address can't be empty")]
    public string HouseNumber { get; set; }
    [Required(ErrorMessage = "City can't be empty")]
    public string City { get; set; }
    [Required(ErrorMessage = "Province can't be empty")]
    public string Province { get; set; }
}

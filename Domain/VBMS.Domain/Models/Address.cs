namespace VBMS.Domain.Models;

public class Address : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return HouseNumber;
        yield return City;
        yield return Country;

    }
    [Required]
    public string HouseNumber { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
}

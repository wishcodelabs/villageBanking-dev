namespace VBMS.Domain.Models;

public class Address : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return HouseNumber;
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return PostalCode;
    }
    public Address() { }
    public Address(string street, string city, string state, string country, string zipcode) : this()
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = zipcode;
    }
    public string HouseNumber { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string? PostalCode { get; set; }


}

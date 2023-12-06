using System.Collections.Generic;

namespace BlazoredFluentValidation.Entities;

public record Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Address PrimaryAddress { get; set; } = new();

    public IList<Address> OtherAddresses { get; set; } = new List<Address>();

    public void AddEmptyAddress()
    {
        OtherAddresses.Add(new Address());
    }
}
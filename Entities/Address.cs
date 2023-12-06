namespace BlazoredFluentValidation.Entities;

public record Address
{
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string PostCode { get; set; }
}
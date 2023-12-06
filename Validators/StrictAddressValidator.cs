using System.Text.RegularExpressions;
using BlazoredFluentValidation.Entities;
using FluentValidation;

namespace BlazoredFluentValidation.Validators;

public partial class StrictAddressValidator : AbstractValidator<Address>
{
    [GeneratedRegex("^[a-z0-9-'., ]*$",  RegexOptions.IgnoreCase)]
    private static partial Regex ValidAddressLineRegex();
    
    [GeneratedRegex(@"^[a-z]{1,2}\d[a-z\d]?\s*\d[a-z]{2}$",  RegexOptions.IgnoreCase)]
    private static partial Regex ValidPostCodeRegex();
    
    public StrictAddressValidator()
    {
        RuleFor(address => address.Line1)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Matches(ValidAddressLineRegex());
        
        RuleFor(address => address.Line2)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Matches(ValidAddressLineRegex());

        RuleFor(address => address.PostCode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(6)
            .Matches(ValidPostCodeRegex());
    }
}
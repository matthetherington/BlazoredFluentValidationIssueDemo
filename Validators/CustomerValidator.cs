using System.Linq;
using System.Text.RegularExpressions;
using BlazoredFluentValidation.Entities;
using FluentValidation;

namespace BlazoredFluentValidation.Validators;

public partial class CustomerValidator : AbstractValidator<Customer>
{
    [GeneratedRegex("^[a-z0-9-'.,]*$",  RegexOptions.IgnoreCase)]
    private static partial Regex ValidAddressLineRegex();
    
    [GeneratedRegex(@"^[a-z]{1,2}\d[a-z\d]?\s*\d[a-z]{2}$",  RegexOptions.IgnoreCase)]
    private static partial Regex ValidPostCodeRegex();
    
    public CustomerValidator()
    {
        RuleFor(customer => customer.FirstName)
            .NotEmpty()
            .MaximumLength(20)
            .NotEqual("Dave");
        
        RuleFor(customer => customer.LastName)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(customer => customer.PrimaryAddress.Line1)
            .NotEqual("10 Downing Street");
        
        RuleSet("AddressOnly", () =>
        {
            RuleFor(customer => customer.PrimaryAddress)
                .SetValidator(new PermissiveAddressValidator());
            
            RuleFor(customer => customer.OtherAddresses)
                .NotNull()
                .Must(addresses => addresses?.Count > 0)
                .WithMessage("You must provide at least one address");
            
            RuleForEach(customer => customer.OtherAddresses)
                .SetValidator(new PermissiveAddressValidator());
        });
    }
}
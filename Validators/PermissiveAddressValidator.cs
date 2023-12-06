using BlazoredFluentValidation.Entities;
using FluentValidation;

namespace BlazoredFluentValidation.Validators;

public class PermissiveAddressValidator : AbstractValidator<Address>
{
    public PermissiveAddressValidator()
    {
        RuleFor(address => address.Line1)
            .NotEmpty();

        RuleFor(address => address.Line2)
            .NotEmpty();

        RuleFor(address => address.PostCode)
            .NotEmpty();
    }
}
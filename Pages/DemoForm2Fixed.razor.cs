using BlazoredFluentValidation.Entities;

namespace BlazoredFluentValidation.Pages;

public partial class DemoForm2Fixed
{
    private bool? IsValid { get; set; }
    private Customer Customer { get; set; } = new();
    
    private void HandleValidSubmit()
    {
        IsValid = true;
    }
    
    private void HandleInvalidSubmit()
    {
        IsValid = false;
    }
}
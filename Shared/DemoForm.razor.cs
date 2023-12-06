using BlazoredFluentValidation.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazoredFluentValidation.Shared;

public partial class DemoForm
{
    [Parameter]
    public Customer Customer { get; set; }
    
    [Parameter]
    public bool? IsValid { get; set; }
}
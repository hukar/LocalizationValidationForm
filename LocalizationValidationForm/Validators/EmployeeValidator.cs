using FluentValidation;
using LocalizationValidationForm.Model;
using LocalizationValidationForm.Resources;
using Microsoft.Extensions.Localization;

namespace LocalizationValidationForm.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator(IStringLocalizer<Data> localizer)
    {
        RuleFor(e => e.Name)
            .NotEmpty().Length(3, 15);
        RuleFor(e => e.Age)
            .InclusiveBetween(0, 120);
        RuleFor(e => e.EmployeeType)
            .MustAsync(IsValidType).WithMessage(e => localizer["CustomValidationMessage"]);
    }

    private static async Task<bool> IsValidType(string employeeType, CancellationToken token)
    {
        var supportedTypes = new[] { "Silver", "Gold" };
        await Task.Delay(2000, token);

        return supportedTypes.Contains(employeeType);
    }
}
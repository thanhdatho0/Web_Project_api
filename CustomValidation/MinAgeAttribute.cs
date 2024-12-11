using System.ComponentModel.DataAnnotations;

namespace api.CustomerValidation;

public class MinAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateOnly dateOfBirth)
        {
            return new ValidationResult("Invalid date of birth format.");
        }

        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - dateOfBirth.Year;
        if (today < dateOfBirth.AddYears(age))
        {
            age--;
        }

        if (age < _minimumAge)
        {
            return new ValidationResult($"Age must be at least {_minimumAge} years.");
        }

        return ValidationResult.Success;
    }
}
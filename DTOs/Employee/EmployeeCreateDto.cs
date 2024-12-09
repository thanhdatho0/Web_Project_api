using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Employee;

public class EmployeeCreateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool Male { get; set; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format (yyyy-MM-dd)")]
    public DateOnly DateOfBirth { get; set; }

    [Required(ErrorMessage = "Salary is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format (yyyy-MM-dd)")]
    public DateOnly StartDate { get; set; }

    [Required(ErrorMessage = "ContractUpTo is required.")]
    public int ContractUpTo { get; set; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string ParentPhoneNumber { get; set; } = string.Empty;
}
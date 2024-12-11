using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Employee;

public class EmployeeCreateDto
{
    public EmployeePersonalInfo PersonalInfo { get; set; }
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
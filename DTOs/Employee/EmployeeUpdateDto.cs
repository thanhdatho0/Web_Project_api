using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Employee;

public class EmployeeUpdateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? PhoneNumber { get; set; }
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format (yyyy-MM-dd)")]
    public DateOnly StartDate { get; set; }

    [Required(ErrorMessage = "ContractUpTo is required.")]
    public int ContractUpTo { get; set; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? ParentPhoneNumber { get; set; }
    public int DepartmentId { get; set; }
}
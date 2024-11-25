using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Employee;

public class EmployeeUpdateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Length(10, 11, ErrorMessage = "Not a valid number")]
    public string? PhoneNumber { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartDate { get; set; }
    [Length(10, 11, ErrorMessage = "Not a valid number")]
    public int ContractUpTo { get; set; }
    public string? ParentPhoneNumber { get; set; }
    public int? DepartmentId { get; set; }
}
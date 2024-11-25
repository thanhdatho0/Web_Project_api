namespace api.DTOs.Employee;

public class EmployeeCreateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool Male { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartDate { get; set; }
    public int ContractUpTo { get; set; }
    public string? ParentPhoneNumber { get; set; }
    public int? DepartmentId { get; set; }
}
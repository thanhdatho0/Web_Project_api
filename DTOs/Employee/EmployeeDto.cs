
using api.DTOs.Department;

namespace api.DTOs.Employee;

public class EmployeeDto
{
    public string? Name { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartDate { get; set; }
    public int ContractUpTo { get; set; }
    public DepartmentDto? Department { get; set; }
}
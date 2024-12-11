
using System.ComponentModel;

namespace api.DTOs.Employee;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public EmployeePersonalInfo PersonalInfo { get; set; }
    public decimal Salary { get; set; }
    public DateOnly StartDate { get; set; }
    public int ContractUpTo { get; set; }
}
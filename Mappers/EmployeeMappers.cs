using api.DTOs.Employee;
using api.Models;

namespace api.Mappers;

public static class EmployeeMappers
{
    public static EmployeeDto ToEmployeeDto(this Employee employee)
    {
        return new EmployeeDto
        {
            Name = employee.FullName,
            Salary = employee.Salary,
            StartDate = employee.StartDate,
            ContractUpTo = employee.ContractUpTo,
        };
    }

    public static Employee ToCreateEmployeeDto(this EmployeeCreateDto employeeCreateDto)
    {
        return new Employee
        {
            FirstName = employeeCreateDto.FirstName,
            LastName = employeeCreateDto.LastName,
            Male = employeeCreateDto.Male,
            PhoneNumber = employeeCreateDto.PhoneNumber,
            Address = employeeCreateDto.Address,
            DateOfBirth = employeeCreateDto.DateOfBirth,
            Salary = employeeCreateDto.Salary,
            StartDate = employeeCreateDto.StartDate,
            ContractUpTo = employeeCreateDto.ContractUpTo,
            ParentPhoneNumber = employeeCreateDto.ParentPhoneNumber,
        };
    }

    public static Employee ToEmployeeUpdate(this EmployeeUpdateDto employee)
    {
        return new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            Salary = employee.Salary,
            StartDate = employee.StartDate,
            ContractUpTo = employee.ContractUpTo,
            ParentPhoneNumber = employee.ParentPhoneNumber
        };
    }
}
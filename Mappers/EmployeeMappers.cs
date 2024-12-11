using api.DTOs.Employee;
using api.Models;

namespace api.Mappers;

public static class EmployeeMappers
{
    public static EmployeeDto ToEmployeeDto(this Employee employee)
    {
        return new EmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            PersonalInfo = new EmployeePersonalInfo
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Male = employee.Male,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                DateOfBirth = employee.DateOfBirth,
            },
            Salary = employee.Salary,
            StartDate = employee.StartDate,
            ContractUpTo = employee.ContractUpTo,
        };
    }

    public static Employee ToCreateEmployeeDto(this EmployeeCreateDto employeeCreateDto)
    {
        return new Employee
        {
            FirstName = employeeCreateDto.PersonalInfo.FirstName,
            LastName = employeeCreateDto.PersonalInfo.LastName,
            Male = employeeCreateDto.PersonalInfo.Male,
            PhoneNumber = employeeCreateDto.PersonalInfo.PhoneNumber,
            Address = employeeCreateDto.PersonalInfo.Address,
            DateOfBirth = employeeCreateDto.PersonalInfo.DateOfBirth,
            Salary = employeeCreateDto.Salary,
            StartDate = employeeCreateDto.StartDate,
            ContractUpTo = employeeCreateDto.ContractUpTo,
            ParentPhoneNumber = employeeCreateDto.ParentPhoneNumber,
        };
    }

    public static void ToEmployeeUpdate(this Employee employee, EmployeeUpdateDto employeeUpdateDto)
    {
            employee.FirstName = employeeUpdateDto.PersonalInfo.FirstName;
            employee.LastName = employeeUpdateDto.PersonalInfo.LastName;
            employee.PhoneNumber = employeeUpdateDto.PersonalInfo.PhoneNumber;
            employee.Salary = employeeUpdateDto.Salary;
            employee.StartDate = employeeUpdateDto.StartDate;
            employee.ContractUpTo = employeeUpdateDto.ContractUpTo;
            employee.ParentPhoneNumber = employeeUpdateDto.ParentPhoneNumber;
    }
}
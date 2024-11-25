using api.DTOs.Department;
using api.Models;

namespace api.Mappers;

public static class DepartmentMappers
{
    public static DepartmentDto ToDepartmentDto(this Department department)
    {
        return new DepartmentDto
        {
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName,
        };
    }

    public static Department ToCreateDepartmentDto(this DepartmentCreateDto departmentCreateDto)
    {
        return new Department
        {
            DepartmentName = departmentCreateDto.DepartmentName,
            ManagerId = departmentCreateDto.ManagerId,
        };
    }

    public static Department ToUpdateDepartmentDto(this DepartmentUpdateDto departmentUpdateDto)
    {
        return new Department
        {
            DepartmentName = departmentUpdateDto.DepartmentName,
            ManagerId = departmentUpdateDto.ManagerId,
        };
    }
}
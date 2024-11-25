namespace api.DTOs.Department;

public class DepartmentCreateDto
{
    public string? DepartmentName { get; set; }
    public int ManagerId { get; set; }
}
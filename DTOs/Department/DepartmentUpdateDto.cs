using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Department;

public class DepartmentUpdateDto
{
    [Required(ErrorMessage = "DepartmentName is required.")]
    public string? DepartmentName { get; set; }
    public int ManagerId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
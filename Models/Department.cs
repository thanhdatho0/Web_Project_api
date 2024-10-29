
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId {get; set;}
        public string? DepartmentName {get; set;}
        public int ManagerId {get; set;}
        public int CompanyId {get; set;}
        public Company? Company {get; set;}
        public List<Employee>? Employees {get; set;}
    }
}
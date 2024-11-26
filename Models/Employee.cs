using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Employees")]
    public class Employee : Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public DateOnly StartDate { get; set; }
        public int ContractUpTo { get; set; }
        public string? ParentPhoneNumber { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
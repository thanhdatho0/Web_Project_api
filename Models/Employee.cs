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
        [Column(TypeName = "timestamp")]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ContractUpTo { get; set; }
        [Length(10, 11, ErrorMessage = "Not a valid number")]
        public string? ParentPhoneNumber { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
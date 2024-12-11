using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Employees")]
    public class Employee : Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [DefaultValue("")]
        public string EmployeeCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public DateOnly StartDate { get; set; }
        public int ContractUpTo { get; set; }
        [Length(10, 11, ErrorMessage = "Phone number must be 10 or 11 numbers long.")]
        [Column(TypeName = "varchar(11)")]
        public string? ParentPhoneNumber { get; set; }
        public List<Order> Orders { get; set; } = [];
    }
}
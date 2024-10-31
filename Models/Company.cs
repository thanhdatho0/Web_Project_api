
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; } = string.Empty; public string? Address { get; set; }
        public string? Slogan { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? FoundDate { get; set; }
        public string? Description { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
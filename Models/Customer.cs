using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Customers")]
    public class Customer : Person
    {
        [Key] public string CustomerId { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        [MaxLength(500)]
        public string? Avatar { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = [];
    }
}
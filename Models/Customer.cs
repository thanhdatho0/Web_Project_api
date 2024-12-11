using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Customers")]
    public class Customer : Person
    {
        [Key] 
        [Description("")]
        public string CustomerId { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [MaxLength(500)]
        [DefaultValue("")]
        public string? Avatar { get; set; }
        public List<Order> Orders { get; set; } = [];
    }
}
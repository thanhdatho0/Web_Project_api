
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Customer : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
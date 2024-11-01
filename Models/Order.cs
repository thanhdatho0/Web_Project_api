
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime OrderExportDateTime { get; set; }
        public string? OrderNotice { get; set; }
        public List<Product>? Products { get; set; }
        public List<OrderDetail>? Details { get; set; }
    }
}
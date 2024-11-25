using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace api.Models
{
    [Table("Orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime OrderExportDateTime { get; set; }
        public string? OrderNotice { get; set; }
        public List<Product>? Products { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
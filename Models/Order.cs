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
        public string? CustomerId { get; set; } = string.Empty;
        public Customer? Customer { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime OrderExportDateTime { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? OrderNotice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = [];
    }
}
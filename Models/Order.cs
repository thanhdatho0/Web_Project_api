using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace api.Models
{
    [Table("Orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [DefaultValue("")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime OrderExportDateTime { get; set; }
        [Column(TypeName = "varchar(300)")]
        [DefaultValue("")]
        public string? OrderNotice { get; set; }
        [DefaultValue(false)]
        public bool Confirmed { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = [];
    }
}
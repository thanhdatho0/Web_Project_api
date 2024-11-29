using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; } = new();
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public int SizeId { get; set; }
        public Size? Size { get; set; }
        public int Amount { get; set; }
    }
}
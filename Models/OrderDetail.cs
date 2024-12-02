using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; } = new();
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        public int Amount { get; set; }
    }
}
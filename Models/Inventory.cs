using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Inventory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int SizeId { get; set; }
    public Size? Size { get; set; }
    public int ColorId { get; set; }
    public Color? Color { get; set; }
    public int Quantity { get; set; }
    public int InStock { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = [];
}
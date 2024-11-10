
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Product;

public class ProductCreateDto
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string? Description {get; set;}
    public decimal Cost {get; set;}
    public int Stock {get; set;}
    public int CategoryId {get; set;}
    public int ProviderId {get; set;}
}
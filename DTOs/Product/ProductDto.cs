namespace api.DTOs.Product;

public class ProductDto
{
    public string Name { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public decimal Price {get; set;}
    public string? Description {get; set;}
    public decimal Cost {get; set;}
    public int Stock {get; set;}
}
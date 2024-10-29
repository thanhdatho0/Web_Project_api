
namespace api.Models
{

    public class ProductImage
    {
        //Properties
        public int ImageId {get; set;}
        public int ProductId {get; set;}
        public Image? Image {get; set;}
        public Product? Product {get; set;}
    }
}
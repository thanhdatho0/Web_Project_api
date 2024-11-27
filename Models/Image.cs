using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Images")]
    public class Image
    {
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string Url { get; set; }
        [Column(TypeName = "varchar(100)")] 
        public string Alt { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int ColorId { get; set; }
        public Color Color { get; set; } = new Color();
    }
}
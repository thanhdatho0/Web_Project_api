using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Images")]
    public class Image
    {
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Url { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? Alt { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
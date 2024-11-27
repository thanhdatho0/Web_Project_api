using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Providers")]
    public class Provider
    {
        public int ProviderId { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Length(0, 100)]
        public string? ProviderEmail { get; set; }
        [Column(TypeName = "varchar(11)")]
        public string ProviderPhone { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        public string ProviderCompanyName { get; set; } = string.Empty;
        public List<Product>? ProviderProducts { get; set; } = new List<Product>();
    }
}
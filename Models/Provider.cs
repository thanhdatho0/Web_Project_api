using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Providers")]
    public class Provider
    {
        public int ProviderId { get; set; }
        public string? ProviderEmail { get; set; }
        public string ProviderPhone { get; set; } = string.Empty;
        public string ProviderCompanyName { get; set; } = string.Empty;
        public List<Product>? ProviderProducts { get; set; } = new List<Product>();
    }
}
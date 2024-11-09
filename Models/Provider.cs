using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string? ProviderEmail { get; set; }
        public string ProviderPhone { get; set; } = string.Empty;
        public string ProviderCompanyName { get; set; } = string.Empty;
        public List<Product>? ProviderProducts { get; set; }
    }
}
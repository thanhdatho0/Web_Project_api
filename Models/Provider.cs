
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? ProviderEmail { get; set; }
        [Required]
        public string ProviderPhone { get; set; } = string.Empty;
        [Required]
        public string ProviderCompanyName { get; set; } = string.Empty;
        public List<Product>? ProviderProducts { get; set; }
    }
}
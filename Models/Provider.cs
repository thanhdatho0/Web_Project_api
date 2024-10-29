
namespace api.Models
{
    public class Provider
    { 
        public int ProviderId {get; set;}
        public string? ProviderEmail {get; set;}
        public string? ProviderPhone {get; set;}
        public string? ProviderCompanyName {get; set;}
        public List<Product>? ProviderProducts {get; set;}
    }
}
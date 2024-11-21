using api.DTOs.Product;

namespace api.DTOs.Providerr
{
    public class ProviderDto
    {
        public int ProviderId { get; set; }
        public string? ProviderEmail { get; set; }
        public string ProviderPhone { get; set; } = string.Empty;
        public string ProviderCompanyName { get; set; } = string.Empty;
        public List<ProductDto>? Products { get; set; }
    }
}

using api.DTOs.Category;

namespace api.DTOs.TargetCustomer
{
    public class TargetCustomerDto
    {
        public int TargetCustomerId { get; set; }
        public string TargetCustomerName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public List<CategoryDto>? Categories { get; set; }
    }
}
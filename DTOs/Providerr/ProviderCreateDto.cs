using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Providerr
{
    public class ProviderCreateDto
    {
        public string? ProviderEmail { get; set; }
        public string ProviderPhone { get; set; } = string.Empty;
        public string ProviderCompanyName { get; set; } = string.Empty;
    }
}
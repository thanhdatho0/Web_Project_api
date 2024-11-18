using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.Size
{
    public class SizeDto
    {
        public int SizeId { get; set; }
        public string SizeValue { get; set; } = string.Empty;
        public List<ProductSize>? ProductSizes { get; set; }

    }
}
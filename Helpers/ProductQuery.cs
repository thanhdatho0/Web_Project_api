using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class ProductQuery
    {
        public string? CategoryId { get; set; } = null;
        public string? ColorId { get; set; } = null;
        public string? SizeId { get; set; } = null;
        public string? Price { get; set; } = null;
        public string? ProductId { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 24;
    }
}
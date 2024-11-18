using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Size
{
    public class SizeCreateDto
    {
        [Required(ErrorMessage = "SizeValue is required.")]
        [RegularExpression("^(S|M|L|XL|XXL)$", ErrorMessage = "SizeValue must be one of the following: S, M, L, XL, XXL.")]
        public string SizeValue { get; set; } = string.Empty;
    }
}
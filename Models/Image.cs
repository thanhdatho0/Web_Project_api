
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Image
    {
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId {get; set;}
        public string? Url {get; set;}
        public string? Alt {get; set;}
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
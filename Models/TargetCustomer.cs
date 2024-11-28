
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class TargetCustomer
    {
        [Key]
        //Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TargetCustomerId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string TargetCustomerName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        [Column(TypeName = "varchar(50)")]
        public string Alt { get; set; } = string.Empty;
        public List<Category> Categories { get; set; } = [];
    }
}
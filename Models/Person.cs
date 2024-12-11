
using System.ComponentModel;
using api.CustomerValidation;

namespace api.Models
{
    public class Person
    {
        [DefaultValue("")]
        public required string FirstName { get; set; } 
        [DefaultValue("")]
        public required string LastName { get; set; } 
        public bool Male { get; set; }
        [DefaultValue("")]
        public required string PhoneNumber { get; set; } 
        [DefaultValue("")]
        public required string Address { get; set; } 
        [MinAge(18)]
        public required DateOnly DateOfBirth { get; set; }
    }
}

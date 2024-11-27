

using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Male { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
    }
}

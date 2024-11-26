

using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Male { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
    }
}

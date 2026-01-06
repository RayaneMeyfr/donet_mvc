using System.ComponentModel.DataAnnotations;

namespace Exercice1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MobileNumber { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace SpellsReference.Models
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
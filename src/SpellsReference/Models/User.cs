using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
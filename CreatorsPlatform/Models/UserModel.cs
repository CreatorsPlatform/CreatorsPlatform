using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatorsPlatform.Models
{
    // [PrimaryKey(nameof(ID))]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [NotMapped]
        public IList<User> OneUserLoaded { get; set; }
        
        // Relationships
    }
}
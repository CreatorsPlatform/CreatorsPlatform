using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatorsPlatform.Models
{
    // [PrimaryKey(nameof(ID))]
    internal class User
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? Name { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [NotMapped]
        public IList<User> OneUserLoaded { get; set; }
    }
}
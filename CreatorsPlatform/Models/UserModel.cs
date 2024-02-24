

using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CreatorsPlatform.Models
{
    // [PrimaryKey(nameof(ID))]
    public class User
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PaymentMethod { get; set; }
        public int CreatorID { get; set; }
        public int CategoryID { get; set; }
        public int UserPoint {  get; set; }
        public bool EmailVerification {  get; set; }
        public bool PhoneVerification { get; set; }

        //[NotMapped]
        //public IList<User> OneUserLoaded { get; set; }
        
        // Relationships / 關係
    }
}
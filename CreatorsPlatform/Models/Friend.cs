namespace CreatorsPlatform.Models
{
    /// <summary>
    /// stores friend instance
    /// </summary>
    public class Friend
    {
        public int Id { get; set; }
        public int RequestUserID { get; set; }
        public int RequestedUserID { get; set; }
        public bool isAccepted { get; set; }
    }
}

namespace CreatorsPlatform.Models
{
    /// <summary>
    /// stores subscription instance / 存放網站運營至今所有建立的訂閱
    /// </summary>
    public class Subscription
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public int CreatorID { get; set; }
        public int UserID { get; set; }

        public int CategoryID { get; set; }
        
    }
}

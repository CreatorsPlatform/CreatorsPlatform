namespace CreatorsPlatform.Models
{
    public class Commission
    {
        public int CommissionID { get; set; }
        public int Price { get; set; }
        public DateTime CommissionDate { get; set; }
        public DateTime DeadLineDate { get; set; }
        public int Status { get; set; }
        public string PaymentMethod { get; set; }
        public int CreatorID {  get; set; }
        public int UserID { get; set; }

    }
}

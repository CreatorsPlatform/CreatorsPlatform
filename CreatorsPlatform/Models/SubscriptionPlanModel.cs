namespace CreatorsPlatform.Models
{
    public class SubscriptionPlan
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price {  get; set; }
        public string Description { get; set; }
        public int SubLevel { get; set; }
        public int CreatorID { get; set; }

    }
}

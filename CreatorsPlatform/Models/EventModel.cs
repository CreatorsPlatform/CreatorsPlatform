namespace CreatorsPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] Image { get; set; }
        public string Url { get; set; }
        public int CategoryID { get; set; }
    }
}

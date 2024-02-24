namespace CreatorsPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Content
    {
        public int ContentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime PullOffDate { get; set; }
        public string ContentUrl { get; set; }
        public int ContentLikes { get; set; }
        public int Inventory {  get; set; }
        public int Price { get; set; }
        public int SubLevel { get; set; }
        public int TagID { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        
    }
}

namespace GetPriceUrl.Infrastructure.Models
{
    public class LaptopURL
    {
        public int LaptopURLID { get; internal set; }
        public int? LaptopID { get; set; }
        public int? WebsiteID { get; set; }
        public string URL { get; set;}
        public string? Price { get; set; }
    }
}

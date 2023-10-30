namespace GetPriceUrl.Dtos
{
    public class CrawlReq
    {
        public int LaptopURLID { get; set; }

        public string URL { get; set; }

        public string? Price { get; set; }
    }
}

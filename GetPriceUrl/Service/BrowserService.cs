using PuppeteerSharp;

namespace GetPriceUrl.Service
{
    public class BrowserService : IBrowserService
    {
        public async Task DownloadAsync()
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
        }

        public async Task<IBrowser> LaunchAsync(LaunchOptions options)
        {
            return await Puppeteer.LaunchAsync(options);
        }
    }
}

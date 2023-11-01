using GetPriceUrl.Helpers;
using PuppeteerSharp;

namespace GetPriceUrl.Service
{
    public class PriceCrawlService
    {
        private readonly IBrowserService _browserService;

        public PriceCrawlService(IBrowserService browserService)
        {
            _browserService = browserService;
        }
        public async Task<Dictionary<string, string>> CrawlPricesAsync(List<string> urls)
        {
            await _browserService.DownloadAsync();
            var browser = await _browserService.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] {
                    "--disable-gpu",
                    "--disable-dev-shm-usage",
                    "--no-sandbox"
                },

            });

            Dictionary<string, string> urlPriceMap = new Dictionary<string, string>();

            await Parallel.ForEachAsync(urls, async (url, token) =>
            {
                var page = await browser.NewPageAsync();
                await page.SetCacheEnabledAsync(true);
                page.DefaultNavigationTimeout = 90000;
                await page.GoToAsync(url);

                string domain = GetPriceHelper.GetDomainFromUrl(url);

                var currentPriceSelector = SelectorByDomain._selectors[domain]["currentPrice"];

                var currentPriceNode = await page.QuerySelectorAsync(currentPriceSelector);

                if (currentPriceNode != null)
                {

                    string currentPrice = await page.EvaluateFunctionAsync<string>("element => element.textContent", currentPriceNode);

                    string price = GetPriceHelper.RegexPrice(currentPrice);
                    urlPriceMap[url] = price;
                }

                await page.CloseAsync();

            });

            foreach (var url in urls)
            {
                var price = urlPriceMap[url];
                urlPriceMap[url] = price;
            }

            return urlPriceMap;
        }
    }
}

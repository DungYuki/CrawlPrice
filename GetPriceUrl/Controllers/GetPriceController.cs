using GetPriceUrl.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PuppeteerSharp;
using System.Text.RegularExpressions;

namespace GetPriceUrl.Controllers
{
    [Route("api")]
    [ApiController]
    public class GetPriceController : ControllerBase
    {
        private readonly IBrowserService _browserService;

        public GetPriceController(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        [HttpGet("get-price")]
        public async Task<IActionResult> GetPrice(string url)
        {
            var urls = new List<string> { url };

            await _browserService.DownloadAsync();
            var browser = await _browserService.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });

            string RegexPrice(string price)
            {
                return Regex.Replace(price, "[^0-9]", "");
            }

            List<string> prices = new List<string>();

            await Parallel.ForEachAsync(urls, async (url, token) =>
            {
                var page = await browser.NewPageAsync();
                await page.GoToAsync(url);

                string selector = SelectorByDomain._selector.FirstOrDefault(entry => url.Contains(entry.Key)).Value; ;
                var priceNode = await page.QuerySelectorAsync(selector);

                string price = await page.EvaluateFunctionAsync<string>("element => element.textContent", priceNode);

                await page.CloseAsync();

                prices.Add(RegexPrice(price));
            });

            return Ok(prices);
        }
    }
}

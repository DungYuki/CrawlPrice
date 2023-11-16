using GetPriceUrl.Dtos;
using GetPriceUrl.Infrastructure;
using GetPriceUrl.Infrastructure.Models;
using GetPriceUrl.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PuppeteerSharp;
using System;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Text.RegularExpressions;
using GetPriceUrl.Helpers;
using System.Collections.Generic;

namespace GetPriceUrl.Controllers
{
    [Route("api")]
    [ApiController]
    public class GetPriceController : ControllerBase
    {
        private readonly PriceCrawlService _priceCrawlService;
        private readonly LaptopPriceDbContext _dbcontext;
        private readonly LaptopUrlService _laptopUrlService;

        public GetPriceController(LaptopPriceDbContext dbcontext, 
                                  PriceCrawlService priceCrawlService,
                                  LaptopUrlService laptopUrlService)
        {
            _dbcontext = dbcontext;
            _priceCrawlService = priceCrawlService;
            _laptopUrlService = laptopUrlService;
        }

        [HttpGet("test-get-db")]
        public async Task<IActionResult> GetURL()
        {
            var data = await _laptopUrlService.GetLaptopURL();

            List<string> urls = data.Select(x => x.URL).ToList();

            var urlPriceMap = await _priceCrawlService.CrawlPricesAsync(urls);

            foreach (var laptop in data)
            {
                string crawlPrice = urlPriceMap[laptop.URL];

                laptop.Price = crawlPrice;
            }

            var result = await _laptopUrlService.UpdateLaptopURLPrice(data);

            return Ok(result);
        }
        
    }
}

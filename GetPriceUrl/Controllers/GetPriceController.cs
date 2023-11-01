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
            var data = _dbcontext.Set<LaptopURL>().Select(x => new CrawlReq
            {
                LaptopURLID = x.LaptopURLID,
                URL = x.URL
            }).ToList();

            var result = await GetPrice(data);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice(List<CrawlReq> reqs)
        {
            List<string> urls = reqs.Select(x => x.URL).ToList();

            var urlPriceMap = await _priceCrawlService.CrawlPricesAsync(urls);

            foreach (var req in reqs)
            {
                string crawlPrice = urlPriceMap[req.URL];

                req.Price = crawlPrice;
            }

            var result = await _laptopUrlService.UpdateLaptopURLPrice(reqs);

            return Ok(result);

        }
        
    }
}

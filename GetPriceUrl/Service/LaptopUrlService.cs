using GetPriceUrl.Dtos;
using GetPriceUrl.Infrastructure;
using GetPriceUrl.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetPriceUrl.Service
{
    public class LaptopUrlService
    {
        
        private readonly LaptopPriceDbContext _dbcontext;

        public LaptopUrlService(LaptopPriceDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<CrawlReq>> GetLaptopURL()
        {
            return await _dbcontext.Set<LaptopURL>()
                           .Select(x => new CrawlReq
                           {
                               LaptopURLID = x.LaptopURLID,
                               URL = x.URL
                           })
                           .ToListAsync();
        }

        public async Task<bool> UpdateLaptopURLPrice(List<CrawlReq> reqs)
        {
            try
            {
                foreach (var req in reqs)
                {
                    var LaptopURLID = req.LaptopURLID;
                    var Price = req.Price;

                    var LaptopURL = _dbcontext.Set<LaptopURL>().Where(u => u.LaptopURLID == LaptopURLID).FirstOrDefault();

                    if (LaptopURL != null)
                    {
                        LaptopURL.Price = Price;
                    }

                }

                await _dbcontext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task GetCheapestLaptop() 
        {
            
        }
        public Task GetExpensiveLaptop()
        {
            
        }
        

    }
}

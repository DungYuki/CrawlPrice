using GetPriceUrl.Dtos;
using GetPriceUrl.Infrastructure;
using GetPriceUrl.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetPriceUrl.Service
{
    public class UpdatePriceDbService
    {
        private readonly LaptopPriceDbContext _dbcontext;

        public UpdatePriceDbService(LaptopPriceDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> UpdatePrices(List<CrawlReq> reqs)
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
    }
}

using PuppeteerSharp;
using System.Threading.Tasks;

namespace GetPriceUrl.Service
{
    public interface IBrowserService
    {
        Task DownloadAsync();
        Task<IBrowser> LaunchAsync(LaunchOptions options);
    }
}

using System.Threading.Tasks;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace RepoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinMarketCapController : ControllerBase
    {
        private readonly ICoinMarketCapService _coinMarketCapService;

        public CoinMarketCapController(ICoinMarketCapService coinMarketCapService)
        {
            _coinMarketCapService = coinMarketCapService;
        }

        [HttpGet]
        public async Task<string> Get(string symbol)
        {
            return await _coinMarketCapService.Get(symbol);
        }
    }
}
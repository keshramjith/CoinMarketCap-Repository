using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoWebAPI.Interfaces;

namespace RepoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinMarketCapController : ControllerBase
    {
        private readonly ICoinMarketCapQuoteRepository _coinMarketCapQuoteRepositoryQuote;

        public CoinMarketCapController(ICoinMarketCapQuoteRepository coinMarketCapQuoteRepositoryQuote)
        {
            _coinMarketCapQuoteRepositoryQuote = coinMarketCapQuoteRepositoryQuote;
        }

        /*
         * 
         */
        public async Task<string> Get(string symbol, string convert)
        {
            return await _coinMarketCapQuoteRepositoryQuote.FetchFromApi(symbol, convert);
        }
    }
}
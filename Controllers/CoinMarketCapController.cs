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
         * Uses values from query string and is passed into the repository
         * It expects back a string message, of whether data as been added to the database
         * Or an error message if something went wrong
         * Displays this reponse
         */
        public async Task<string> Get(string symbol, string convert)
        {
            return await _coinMarketCapQuoteRepositoryQuote.FetchFromApi(symbol, convert);
        }
    }
}
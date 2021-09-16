using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RepoWebAPI.Entities;
using RepoWebAPI.Interfaces;
using RepoWebAPI.Objects;
using Services;

namespace RepoWebAPI.Repository
{
    public class CoinMarketCapQuoteRepository: ICoinMarketCapQuoteRepository
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly CoinMarketCapQuoteDbContext _coinMarketCapQuoteDbContext;
        private readonly JsonSerializerSettings _settings;

        public CoinMarketCapQuoteRepository(ICoinMarketCapService coinMarketCapService, CoinMarketCapQuoteDbContext coinMarketCapQuoteDbContext)
        {
            _coinMarketCapService = coinMarketCapService;
            _coinMarketCapQuoteDbContext = coinMarketCapQuoteDbContext;
            _settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }

        /*
         * Receives symbol and convert values from controller
         * Passes symbol and convert to service
         * retrieves json from service, and convert it to an object of type CoinMarketCapAPIResponseQuote
         * This will be used to check if there were any errors, if so, return the error message
         * otherwise add the CoinMarketCapQuotes in res.Value to the DBContext and save changes
         * Return a success message upon saving changes to database
         */
        public async Task<string> FetchFromApi(string symbol, string convert)
        {
            var jsonResult = await _coinMarketCapService.Get(symbol, convert);
            var res = JsonConvert.DeserializeObject<CoinMarketCapAPIResponseQuote>(jsonResult, _settings);
            if (res.Status.ErrorCode == 0)
            {
                foreach (var quote in res.Data)
                {
                    _coinMarketCapQuoteDbContext.Add(quote.Value);
                }
                
                _coinMarketCapQuoteDbContext.SaveChanges();

                return "Data added to database";
            }
            else
            {
                return res.Status.ErrorMessage;
            }
        }

        /*
         * Fetches all quote records from database.
         */
        public IQueryable<CoinMarketCapQuote> GetAll()
        {
            return _coinMarketCapQuoteDbContext.Set<CoinMarketCapQuote>();
        }

        /*
         * Fetches all quotes for a certain symbol from the database.
         */
        public IQueryable<CoinMarketCapQuote> Get(string symbol)
        {
            return _coinMarketCapQuoteDbContext.Set<CoinMarketCapQuote>().Where(_ => _.Symbol == symbol);
        }
    }
}

using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<string> FetchFromApi(string symbol, string convert)
        {
            var jsonResult = await _coinMarketCapService.Get(symbol, convert);
            var res = JsonConvert.DeserializeObject<CoinMarketCapAPIResponseQuote>(jsonResult, _settings);
            if (res.Status.ErrorCode == 0)
            {
                foreach (var quote in res.Data)
                {
                    _coinMarketCapQuoteDbContext.Add(quote);
                }

                return "Data added to database";
            }
            else
            {
                return res.Status.ErrorMessage;
            }
        }

        
        public Task<IQueryable<CoinMarketCapQuote>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<CoinMarketCapQuote> Get(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
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
        private readonly JsonSerializerSettings _settings;

        public CoinMarketCapQuoteRepository(ICoinMarketCapService coinMarketCapService)
        {
            _coinMarketCapService = coinMarketCapService;
            _settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
            // inject db context in ctor
        }
        public async Task<CoinMarketCapAPIResponseQuote> FetchFromApi(string symbol, string convert)
        {
            var jsonResult = await _coinMarketCapService.Get(symbol, convert);
            var res = JsonConvert.DeserializeObject<CoinMarketCapAPIResponseQuote>(jsonResult, _settings);
            return res;
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
